using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Cabin
    {
        public int Id { get; set; }
        public int CabinNo { get; set; }
        public int PatientBed { get; set; }
        public int GuestBed { get; set; }
        public int Rent { get; set; }
        public string Category { get; set; }

    }
}