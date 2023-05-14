﻿using AutoMapper;
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
        public static List<PatientDTO> GetPatients()
        {
            var data = DataAccessFactory.PatientData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Patient, PatientDTO>();
               
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PatientDTO>>(data);
        }
        public static PatientDTO Get(int id)
        {
            return Convert(DataAccessFactory.PatientData().Get(id));
        }
       
        public static bool Create(PatientDTO patient)
        {
            var data = Convert(patient);
            var res = DataAccessFactory.PatientData().Create(data);

            if (res != null) return true;
            return false;
        }
        public static bool Update(PatientDTO patient)
        {
            var data = Convert(patient);
            var res = DataAccessFactory.PatientData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return (DataAccessFactory.PatientData().Delete(id));
        }

        public static int OPDCount(int PatientId)
        {
            int count = 0;
            var OPDbills = DataAccessFactory.OPDBillData().Get();
            count = OPDbills.Count(c => c.PatientId == PatientId);
            return count;
        }
        public static int IPDCount(int PatientId)
        {
            int count = 0;
            var IPDadmits = DataAccessFactory.IPDAdmitData().Get();
            count = IPDadmits.Count(c => c.PatientId == PatientId);
            return count;
        }
        public static int TotalPaid(int PatientID)
        {
            int amount = 0;
            var PaidOPD = DataAccessFactory.OPDBillData().Get();
            var PaidIPD = DataAccessFactory.IPDBillData().Get();
            amount += (from p in PaidOPD where p.PatientId.Equals(PatientID) select p.PaidAmount).Sum();
            amount += (from p in PaidIPD where p.PatientId.Equals(PatientID) select p.PaidAmount).Sum();
            //amount = PaidOPD.Sum(p => p.Paid)
            return amount;
        }
        public static int CalculateAge(DateTime Dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Dob.Year;
            if (today < Dob.AddYears(age)) age--;
            return age;
        }


        static List<PatientDTO> Convert(List<Patient> patients)
        {
            var data = new List<PatientDTO>();
            foreach (var patient in patients)
            {
                data.Add(new PatientInfoDTO()
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
                    OPDCount = OPDCount(patient.Id),
                    IPDCount = IPDCount(patient.Id),
                    TotalPaid = TotalPaid(patient.Id),
                    Age = CalculateAge(patient.DOB),
                    //Prescriptions = patient.Prescriptions.ToList(),
                    //Appointments = patient.Appointments.ToList(),
                    //IPDAdmits = patient.IPDAdmits.ToList(),
                    //PerformDiags = patient.PerformDiags.ToList(),
                    //OPDBills = patient.OPDBills.ToList(),
                    //Complaints = patient.Complaints.ToList(),
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
            };
        }
        static PatientDTO Convert(Patient patient)
        {
            return new PatientInfoDTO()
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
                OPDCount = OPDCount(patient.Id),
                IPDCount = IPDCount(patient.Id),
                TotalPaid = TotalPaid(patient.Id),
                Age = CalculateAge(patient.DOB),


                //Prescriptions = patient.Prescriptions.ToList(),
                //Appointments = patient.Appointments.ToList(),
                //IPDAdmits = patient.IPDAdmits.ToList(),
                //PerformDiags = patient.PerformDiags.ToList(),
                //OPDBills = patient.OPDBills.ToList(),
                //Complaints = patient.Complaints.ToList(),
            };
        }
    }
}
