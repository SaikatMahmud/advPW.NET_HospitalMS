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
    public class AdminDashboardService
    {
        public static AdminDashboardDTO DashboardInfo()
        {
            var doctor = DataAccessFactory.DoctorData().Get();
            var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Doctor, DoctorDTO>();
                });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DoctorDTO>>(doctor);
            foreach (var d in mapped)
            {
                DateTime stayFrom = DateTime.ParseExact(d.StayFrom, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime stayTill = DateTime.ParseExact(d.StayTill, "h:mm tt", CultureInfo.InvariantCulture);
                DateTime currentTime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "h:mm tt", CultureInfo.InvariantCulture);
                if (currentTime >= stayFrom && currentTime <= stayTill)
                {
                    d.IsAvailable = true;
                }
                else { d.IsAvailable = false; }
            }

            var patient = DataAccessFactory.PatientData().Get();
            var dept = DataAccessFactory.DepartmentData().Get();
            var staff = DataAccessFactory.StaffData().Get();

            var cabin = DataAccessFactory.CabinData().Get();
            var bookedCabin = DataAccessFactory.IPDAdmitData().Get();
            
            var availableCabin = cabin
                .Where(c => !bookedCabin.Any(b => b.CabinId == c.Id && b.Status == "Booked"))
                .Select(c => c.Id)
                .ToList();


            var result = new AdminDashboardDTO()
            {
                TotalDoctor = mapped.Count(),
                AvailableDoctor = mapped.Count(x => x.IsAvailable == true),
                RegisteredPatient = patient.Count(),
                TotalDept = dept.Count(),
                TotalStaff = staff.Count(),
                TotalCabin = cabin.Count(),
                AvailableCabin = availableCabin.Count(),

            };
            return result;

        }
    }
}
