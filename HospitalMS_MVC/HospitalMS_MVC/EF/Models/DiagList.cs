using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class DiagList // available diagnosis list in the hospital
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        public float Cost { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<PerformDiag> PerformDiags { get; set; }
        public DiagList()
        {
            PerformDiags = new List<PerformDiag>();
        }
    }
}