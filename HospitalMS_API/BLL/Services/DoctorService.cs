using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService
    {
        public static List<DoctorDTO> Get()
        {
            var data = DataAccessFactory.DoctorData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<List<DoctorDTO>>(data);
            }
            return null;
        }
        public static DoctorDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<DoctorDTO>(data);
                DateTime stayFrom = DateTime.ParseExact(mapped.StayFrom, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime stayTill = DateTime.ParseExact(mapped.StayTill, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime currentTime = DateTime.ParseExact(DateTime.Now.ToString("HH:mm tt"), "h:mm tt", CultureInfo.InvariantCulture);
                if (currentTime >= stayFrom && currentTime <= stayTill)
                {
                    mapped.IsAvailable = true;
                }
                else { mapped.IsAvailable = false; }
                return mapped;
            }
            return null;
        }

        public static bool Create(DoctorDTO doctor)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Doctor>(doctor);
            var res = DataAccessFactory.DoctorData().Create(mapped);
            return (res != null);
        }
        public static bool Update(DoctorDTO doctor)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO, Doctor>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Doctor>(doctor);
            var res = DataAccessFactory.DoctorData().Update(mapped);
            return (res != null) ? true : false;

        }
        public static bool Delete(int id)
        {
            return (DataAccessFactory.DoctorData().Delete(id));
        }
    }
}
