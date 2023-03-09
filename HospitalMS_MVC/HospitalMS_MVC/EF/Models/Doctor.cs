using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutDoctor { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department{ get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }

    }
}