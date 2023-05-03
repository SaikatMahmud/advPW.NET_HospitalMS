namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.HMSDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.HMSDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Random random = new Random();

            //for (int i = 1; i <= 50; i++)
            //{
            //    context.Patients.AddOrUpdate(new Patient
            //    {
            //        Name = $"patient{i}",
            //        DOB = DateTime.Now.AddYears(-i - 4),
            //        Gender = i % 2 == 0 ? "Female" : "Male",
            //        BloodGroup = i % 4 == 0 ? "AB+" : "O+",
            //        Mobile = $"01987{i + 1}32{i}",
            //        Email = $"patient{i}@gmail.com",
            //        Address = $"Address patient{i}",
            //        Username = $"patient{i}"
            //    });
            //}

            //for (int i = 1; i <= 30; i++)
            //{
            //    context.Staffs.AddOrUpdate(new Staff
            //    {
            //        Name = $"staff{i}",
            //        Designation = "Designation" + i,
            //        Gender = i % 2 == 0 ? "Female" : "Male",
            //        Mobile = $"01887{i + 1}32{i}",
            //        Email = $"staff{i}@gmail.com",
            //        JoinDate = DateTime.Now.AddYears(-i),
            //        Username = $"staff{i}",
            //        DeptId = random.Next(1, 9),
            //        Salary = random.Next(10000, 40000),

            //    });
            //}
            //for (int i = 1; i <= 80; i++)
            //{
            //    context.OPDBills.AddOrUpdate(new OPDBill
            //    {
            //        BillAmount = random.Next(1000, 4000),
            //        PaidAmount = random.Next(1000, 4000),
            //        PatientId = random.Next(109,159),
            //        BillDate = DateTime.Now.AddMonths(-random.Next(1,7)),

            //    });
            //} 

            //for (int i = 1; i <= 22; i++)
            //{
            //    context.Doctors.AddOrUpdate(new Doctor
            //    {
            //        Name = $"doctor{i}",
            //        AboutDoctor = $"This is d{i}",
            //        Designation = i % 4 == 0 ? "Assistant Professor" : "Professor",
            //        Gender = i % 2 == 0 ? "Female" : "Male",
            //        Mobile = $"01711{i + 1}32{i}",
            //        Email = $"doctor{i}@gmail.com",
            //        Room = random.Next(1101, 3301).ToString(),
            //        StayFrom = "11:00 am",
            //        StayTill = "5:00 pm",
            //        JoinDate = DateTime.Now.AddYears(- random.Next(1,4)),
            //        DeptId = random.Next(1,10),
            //        Salary = random.Next(50000, 100000),
            //        Fee = random.Next(500,1001),
            //        Username = $"doctor{i}"

            //    }) ;
            //}

            //for (int i = 1; i <= 200; i++)
            //{
            //    context.Appointments.AddOrUpdate(new Appointment
            //    {

            //        DoctorId = random.Next(35,58),
            //        PatientId = random.Next(109,159),
            //        ScheduleTime = DateTime.Now.AddMonths(-random.Next(1, 7)),
            //        BookTime = DateTime.Now.AddMonths(-random.Next(2, 6)),
            //    });
            //}


            //for (int i = 1; i <=100; i++)
            //{

            //    int? cabin = null;
            //    int? ward = null;
            //    if (i%3 == 0)
            //    {
            //        cabin = random.Next(1, 18);

            //    }
            //    else {
            //        ward = random.Next(1, 6);
            //    }
            //    context.IPDAdmits.AddOrUpdate(new IPDAdmit
            //    {
            //        PatientId = random.Next(109,159),
            //        NightCount = random.Next(1,5),
            //        CabinId = cabin,
            //        WardId = ward,
            //        Status = i % 3 == 0 ? "Booked" : "Released",
            //        AdmitDate = DateTime.Now.AddMonths(-random.Next(1, 7)),
            //    });
            //}  
            //for (int i = 1; i <=140; i++)
            //{
            //    context.IPDBills.AddOrUpdate(new IPDBill
            //    {
            //        PatientId = random.Next(109, 159),
            //        TotalAmount = random.Next(5000, 15000),
            //        PaidAmount = random.Next(5000,15000),
            //        Status = i % 3 == 0 ? "Paid" : "Due",
            //        IPDAdmitId = random.Next(110,210),
            //        PaymentDate = DateTime.Now.AddMonths(-random.Next(1, 6)),
            //    }) ;
            //}

            //for (int i = 1; i <= 80; i++)
            //{
            //    context.OPDBillDetails.AddOrUpdate(new OPDBillDetails
            //    {

            //        OPDBillId = random.Next(101, 180),
            //        DoctorId = random.Next(35, 58),
            //        Amount = random.Next(1000,2000),
            //        Discount = 0
            //    }) ;
            //}



        }
    }
}

