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
    public class OPDBillDetailService
    {
        public static OPDBillAllDetailsDTO GetAllInfo(int odpBilId)
        {
            var opdBill = DataAccessFactory.OPDBillData().Get(odpBilId);
            var data = DataAccessFactory.OPDBillDetailsData().Get();
            var billDetails = (from d in data where d.OPDBillId == odpBilId select d).ToList();
            if (billDetails != null)
            {
                var result = new OPDBillAllDetailsDTO
                {
                    OPDBillId = odpBilId,
                    PatientName = opdBill.Patient.Name,
                    TotalAmount = opdBill.BillAmount,
                    PaidAmount = opdBill.PaidAmount,
                    DoctorName = billDetails[0].Doctor.Name,
                    BillDate = opdBill.BillDate.Date.ToShortDateString(),
                    Status = opdBill.Status,
                    DiagInfo = billDetails.Select(d => new DiagInfo
                    {
                        Amount = (int)d.Amount,
                        DiagnosisName = d.PerformDiag.DiagList.Name
                    }).ToList()
                };
                return result;

                //foreach(var r in billDetails)
                //{
                //    var result = new OPDBillAllDetailsDTO
                //    {
                //        PatientName = r.PerformDiag.Patient.Name,

                //    };
                //}
            }
            return null;

            //var data = DataAccessFactory.OPDBillDetailsData().Get();
            //var billDetails = (from d in data where d.OPDBillId == odpBilId select d).ToList(); 
            //if (billDetails != null)
            //{
            //    var cfg = new MapperConfiguration(c =>
            //    {
            //        c.CreateMap<OPDBillDetails, OPDBillAllDetailsDTO>();
            //        c.CreateMap<OPDBill, OPDBillDTO>();
            //        c.CreateMap<PerformDiag, PerformDiagDTO>();
            //        c.CreateMap<Doctor, DoctorDTO>();
            //        //c.CreateMap<DiagList, DiagListDTO>();    
            //    });
            //    var mapper = new Mapper(cfg);
            //    var mapped = mapper.Map<List<OPDBillAllDetailsDTO>>(billDetails);
            //    return mapped;
            //}
            //return null;
        }
        public static byte[] PrintOPDBillDetails(int opdBillId)
        {
            var result = BLL.GeneratePDF.GetPDF("OPDBillAllDetails", GetAllInfo(opdBillId));
            return result;
        }
    }
}
