using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OPDBillService
    {
        public static List<OPDBillDTO> Get()
        {
            var data = DataAccessFactory.OPDBillData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<OPDBill, OPDBillDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<OPDBillDTO>>(data);
                return mapped;
            }
            return null;
        }



        public static OPDBillDTO Get(int id)
        {
            var data = DataAccessFactory.OPDBillData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<OPDBill, OPDBillDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<OPDBillDTO>(data);
            }
            return null;
        }

        public static bool Create(OPDBillDTO opd)
        {
            var totalAmout = 0;
            var OPDData = new OPDBill
            {
                PatientId = opd.PatientId,
                PaidAmount = opd.PaidAmount,
                BillDate = DateTime.Now,
            };
            var OPDBill = DataAccessFactory.OPDBillData().Create(OPDData);
            foreach (var item in opd.DiagId.ToArray())
            {
                var Diagnosis = DataAccessFactory.DiagListData().Get(item);
                totalAmout += (int)Diagnosis.Cost;
                var diagnosisData = new PerformDiag
                {
                    PatientId = opd.PatientId,
                    DiagId = Diagnosis.Id,
                    Status = "Pending",
                    Cost = (int)Diagnosis.Cost
                };
                var PerfomedDiag = DataAccessFactory.PerformDiagData().Create(diagnosisData);
                var OPDDetailsData = new OPDBillDetails
                {
                    OPDBillId = OPDBill.Id,
                    DoctorId = opd.DoctorId,
                    Amount = (int)PerfomedDiag.Cost,
                    PerformDiagId = PerfomedDiag.Id,
                };
                var BillDetails = DataAccessFactory.OPDBillDetailsData().Create(OPDDetailsData);
            }
            var existOPDBill = DataAccessFactory.OPDBillData().Get(OPDBill.Id);
            existOPDBill.BillAmount = totalAmout;
            if (totalAmout == opd.PaidAmount)
            {
                existOPDBill.Status = "Paid";
            }
            else { existOPDBill.Status = "Due"; }
            DataAccessFactory.OPDBillData().Update(existOPDBill);
            return true;
        }

        public static bool Update(OPDBillDTO opd)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OPDBillDTO, OPDBill>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OPDBill>(opd);
            var res = DataAccessFactory.OPDBillData().Update(mapped);
            return (res != null) ? true : false;

        }

    }
}
