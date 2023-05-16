using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LeaveApplicationService
    {
        public static List<LeaveApplicationDTO> Get()
        {
            var data = DataAccessFactory.LeaveApplicationData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<LeaveApplication, LeaveApplicationDTO>();
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<LeaveApplicationDTO>>(data);
                foreach (var item in mapped)
                {
                    item.StaffName = item.Staff.Name;
                }
                return mapped;
            }
            return null;
        }
        public static LeaveApplicationDTO Get(int id)
        {
            var data = DataAccessFactory.LeaveApplicationData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<LeaveApplication, LeaveApplicationDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<LeaveApplicationDTO>(data);
            }
            return null;
        }
        public static bool Create(LeaveApplicationDTO la)
        {
            la.ApplyDate = DateTime.Now;
            la.Status = "Pending";
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LeaveApplicationDTO, LeaveApplication>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LeaveApplication>(la);
            var res = DataAccessFactory.LeaveApplicationData().Create(mapped);
            return (res != null);
        }
        public static bool Update(LeaveApplicationDTO la)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LeaveApplicationDTO, LeaveApplication>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LeaveApplication>(la);
            var res = DataAccessFactory.LeaveApplicationData().Update(mapped);
            return (res != null) ? true : false;

        }

        public static bool ApproveApplication(int id)
        {
            var existing = DataAccessFactory.LeaveApplicationData().Get(id);
            existing.Status = "Approved";
            var res = DataAccessFactory.LeaveApplicationData().Update(existing);
            return (res != null) ? true : false;
        }
        public static bool RejectApplication(int id)
        {
            var existing = DataAccessFactory.LeaveApplicationData().Get(id);
            existing.Status = "Rejected";
            var res = DataAccessFactory.LeaveApplicationData().Update(existing);
            return (res != null) ? true : false;
        }

        public static bool Delete(int id)
        {
            return (DataAccessFactory.LeaveApplicationData().Delete(id));
        }
    }

}
