using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public int DeptId { get; set; }
        public int Salary { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<LeaveApplication> LeaveApplications { get; set; }
        public Staff()
        {
            LeaveApplications = new List<LeaveApplication>();
        }
    }
}
