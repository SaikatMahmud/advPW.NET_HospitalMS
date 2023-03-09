using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class PerformDiag // diagnosis performed of patients
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int PatientId { get; set; }
        public int DiagId { get; set; }
        public float Amount { get; set; }
        public string StoragePath { get; set; }
        [Required, StringLength(10)]
        public string Status { get; set; }
        public DateTime DeliverDate { get; set; }
        [ForeignKey("DiagId")]
        public virtual DiagList DiagList { get; set; }
        [ForeignKey("BillId")]
        public virtual OPDBill OPDBill { get; set; }
    }
}