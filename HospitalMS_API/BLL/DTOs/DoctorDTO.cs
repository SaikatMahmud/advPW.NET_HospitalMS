using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutDoctor { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Room { get; set; }
        public string StayFrom { get; set; }
        public string StayTill { get; set; }
        public DateTime JoinDate { get; set; }
        public int DeptId { get; set; }
        public int Salary { get; set; }
        public int Fee { get; set; }
        public bool IsAvailable { get; set; }
    }
}
