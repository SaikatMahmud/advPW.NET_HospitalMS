using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
       // public int Discount { get; set; }
        public int PatientId { get; set; }
        public DateTime BillDate { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<OPDBillDetails> OPDBillDetails { get; set; }
        public OPDBill()
        {
            OPDBillDetails = new List<OPDBillDetails>();
        }
    }
}