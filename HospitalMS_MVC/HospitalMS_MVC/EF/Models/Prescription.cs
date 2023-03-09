using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Details { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}