using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Details { get; set; }
        public DateTime ApplyDate { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

    }
}