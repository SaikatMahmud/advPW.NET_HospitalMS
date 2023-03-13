using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class OPDBill
    {
        public int Id { get; set; }
        public float BillAmount { get; set; }
        [Required]
        public float PaidAmount { get; set; }
        public int PatientId { get; set; }
        public DateTime BillDate { get; set; }
        public virtual ICollection<PerformDiag> PerformDiags { get; set; }
        public virtual Finance Finance { get; set; }

        public OPDBill()
        {
            PerformDiags = new List<PerformDiag>();
        }
    }
}