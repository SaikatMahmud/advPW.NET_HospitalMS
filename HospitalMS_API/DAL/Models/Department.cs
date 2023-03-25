using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<DiagList> DiagLists { get; set; }
        public Department()
        {
            Doctors = new List<Doctor>();
            Staffs = new List<Staff>();
            DiagLists = new List<DiagList>();
        }

    }
}
