using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Doctor> Doctors { get; set; }
        //public List<Staff> Staffs { get; set; }
    }
}
