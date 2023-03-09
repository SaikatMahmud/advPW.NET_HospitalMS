using HospitalMS_MVC.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF
{
    public class HMSDb:DbContext
    {
        public DbSet<AvailableDiag> AllTestLists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<DiagRecord> TestRecords { get; set; }
        public DbSet<Ward> Wards { get; set; }

    }
}