using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using iText.Html2pdf;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.IO;
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
                    c.CreateMap<Patient, PatientDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();

                    //c.CreateMap<Doctor, DoctorDeptDTO>();
                    //c.CreateMap<Department, DepartmentDTO>();
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
                    c.CreateMap<Patient, PatientDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();
                    //c.CreateMap<Doctor, DoctorDeptDTO>();
                    //c.CreateMap<Department, DepartmentDTO>();
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
          //  mapped.Status = "Open";
            var res = DataAccessFactory.AppointmentData().Create(mapped);
            return (res != null);
        }
        public static bool Update(AppointmentDTO obj)
        {
            var exist = DataAccessFactory.AppointmentData().Get(obj.Id);
            var data = new Appointment()
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                PatientId = obj.PatientId,
                ScheduleDate = obj.ScheduleDate,
                ScheduleTime = obj.ScheduleTime,
                BookTime = DateTime.Now,
                Fee = exist.Fee,
                Status = obj.Status,
            };

            var res = DataAccessFactory.AppointmentData().Update(data);
            return (res != null) ? true : false;

        }
        public static bool Delete(int id)
        {
            return (DataAccessFactory.AppointmentData().Delete(id));
        }
        public static bool CancelAppointment(int id)
        {
            var existing = DataAccessFactory.AppointmentData().Get(id);
            existing.Status = "Cancelled";
            var res = DataAccessFactory.AppointmentData().Update(existing);
            return (res != null) ? true : false;
        }
        public static bool CloseAppointment(int id)
        {
            var existing = DataAccessFactory.AppointmentData().Get(id);
            existing.Status = "Closed";
            var res = DataAccessFactory.AppointmentData().Update(existing);
            return (res != null) ? true : false;
        }

        public static List<string> AvailableSlot(int DoctorId, DateTime ScheduleDate)
        {
            var booked = (from t in DataAccessFactory.AppointmentData().Get()
                          where (t.DoctorId == DoctorId && t.ScheduleDate.Date == ScheduleDate.Date)
                       || (t.DoctorId == DoctorId && t.ScheduleDate == ScheduleDate && t.Status == "Cancelled")
                          select t).ToList();
            var schedules = DataAccessFactory.DoctorScheduleData().Get();
            var available = schedules
                                .Where(ds => ds.DoctorId == DoctorId)
                                .Select(ds => ds.SlotTime)
                                .Except(booked.Select(a => a.ScheduleTime))
                                .ToList();
            return available;
        }

        public static byte[] PrintAppointment(int appointmentId)
        {
            var result = BLL.GeneratePDF.GetPDF("AppointmentDetails", Get(appointmentId));
            return result;
        }

    }
}
