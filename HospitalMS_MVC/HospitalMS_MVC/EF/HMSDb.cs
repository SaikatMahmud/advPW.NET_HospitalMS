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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DiagList> DiagLists { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<IPDAdmit> IPDAdmits { get; set; }
        public DbSet<IPDBill> IPDBills { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<OPDBill> OPDBills { get; set; }
        public DbSet<OPDBillDetails> OPDBillDetails { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PerformDiag> PerformDiags { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ward> Wards { get; set; }

    }
}