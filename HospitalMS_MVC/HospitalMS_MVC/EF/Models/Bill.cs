using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public int OrderedTestId { get; set; }
        public int PatientId { get; set; }
        public DateTime BillDate { get; set; }
    }
}