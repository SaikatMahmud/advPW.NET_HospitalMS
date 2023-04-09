using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class PatientService
    {
        public static List<PatientDTO> Get()
        {
            var data = DataAccessFactory.PatientData().Get();
            return Convert(data);
        }
        public static object Get(int id)
        {
            return PatientRepoV_0.Get(id);
        }
        public static bool Create(Patient patient)
        {
            return PatientRepoV_0.Create(patient);
        }
        public static bool Update(Patient patient)
        {
            return PatientRepoV_0.Update(patient);
        }


        static List<PatientDTO> Convert(List<Patient> patients)
        {
            var data = new List<PatientDTO>();
            foreach (var patient in patients)
            {
                data.Add(new PatientDTO()
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    DOB = patient.DOB,
                    Gender = patient.Gender,
                    BloodGroup = patient.BloodGroup,
                    Mobile = patient.Mobile,
                    Email = patient.Email,
                    Address = patient.Address,
                    Username = patient.Username,
                    Type = patient.Type,
                    Prescriptions = patient.Prescriptions.ToList(),
                    Appointments = patient.Appointments.ToList(),
                    IPDAdmits = patient.IPDAdmits.ToList(),
                    PerformDiags = patient.PerformDiags.ToList(),
                    OPDBills = patient.OPDBills.ToList(),
                    Complaints = patient.Complaints.ToList(),
                });
            }
            return data;

        }
        static Patient Convert(PatientDTO patient)
        {
            return new Patient()
            {
                Id = patient.Id,
                Name = patient.Name,
                DOB = patient.DOB,
                Gender = patient.Gender,
                BloodGroup = patient.BloodGroup,
                Mobile = patient.Mobile,
                Email = patient.Email,
                Address = patient.Address,
                Username = patient.Username,
                Type = patient.Type,
            };
        }
        static PatientDTO Convert(Patient patient)
        {
            return new PatientDTO()
            {
                Id = patient.Id,
                Name = patient.Name,
                DOB = patient.DOB,
                Gender = patient.Gender,
                BloodGroup = patient.BloodGroup,
                Mobile = patient.Mobile,
                Email = patient.Email,
                Address = patient.Address,
                Username = patient.Username,
                Type = patient.Type,
                Prescriptions = patient.Prescriptions.ToList(),
                Appointments = patient.Appointments.ToList(),
                IPDAdmits = patient.IPDAdmits.ToList(),
                PerformDiags = patient.PerformDiags.ToList(),
                OPDBills = patient.OPDBills.ToList(),
                Complaints = patient.Complaints.ToList(),
            };
        }
    }
}
