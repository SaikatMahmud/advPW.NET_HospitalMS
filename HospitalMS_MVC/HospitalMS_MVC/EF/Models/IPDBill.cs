using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class IPDBill
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int IPDAdmitId { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [Required]
        public virtual IPDAdmit IPDAdmit { get; set; }
    }
}