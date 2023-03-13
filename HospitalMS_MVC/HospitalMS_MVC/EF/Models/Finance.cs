using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Finance //recheck needed
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        [Required]
        public bool Expence { get; set; } //modify needed
        public DateTime Date { get; set; }
        public virtual OPDBill OPDBill { get; set; }

    }
}