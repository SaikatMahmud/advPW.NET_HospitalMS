using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Details { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTill { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Status { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

    }
}
