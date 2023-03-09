using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public Department()
        {
            Doctors = new List<Doctor>();
            Staffs = new List<Staff>();
        }

    }
}