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
    public class StaffService
    {
        public static List<StaffDTO> Get()
        {
            var data = DataAccessFactory.StaffData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<List<StaffDTO>>(data);
            }
            return null;
        }
        public static StaffDTO Get(int id)
        {
            var data = DataAccessFactory.StaffData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<StaffDTO>(data);
            }
            return null;
        }

        public static bool Create(StaffDTO staff)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StaffDTO, Staff>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Staff>(staff);
            var res = DataAccessFactory.StaffData().Create(mapped);
            return (res != null);
        }
        public static bool Update(StaffDTO staff)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<StaffDTO, Staff>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Staff>(staff);
            var res = DataAccessFactory.StaffData().Update(mapped);
            return (res != null) ? true : false;

        }
        public static bool Delete(int id)
        {
            return (DataAccessFactory.StaffData().Delete(id));
        }
    }
}
