using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class OrderedDiag
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime PlaceDate { get; set; }
        public string Status { get; set; }
        public int PatientId { get; set; }
        public DateTime DeliverDate { get; set; }
    }
}