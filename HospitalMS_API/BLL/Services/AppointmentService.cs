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
    public class AppointmentService
    {
        public static List<AppointmentDTO> Get()
        {
            var data = DataAccessFactory.AppointmentData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Appointment, AppointmentDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<List<AppointmentDTO>>(data);
            }
            return null;
        }
        public static AppointmentDTO Get(int id)
        {
            var data = DataAccessFactory.AppointmentData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Appointment, AppointmentDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<AppointmentDTO>(data);
            }
            return null;
        }

        public static bool Create(AppointmentDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AppointmentDTO, Appointment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Appointment>(obj);
            mapped.BookTime = DateTime.Now;
            mapped.Status = "Open";
            var res = DataAccessFactory.AppointmentData().Create(mapped);
            return (res != null);
        }
        public static bool Update(AppointmentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AppointmentDTO, Appointment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Appointment>(obj);
            var res = DataAccessFactory.AppointmentData().Update(mapped);
            return (res != null) ? true : false;

        }
        public static bool Delete(int id)
        {
            return (DataAccessFactory.AppointmentData().Delete(id));
        }
    }
}
