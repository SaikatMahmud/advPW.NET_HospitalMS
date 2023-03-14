using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required, StringLength(25)]

        public string Name { get; set; }
        [StringLength(200)]
        public string AboutDoctor { get; set; }
        [StringLength(20)]
        public string Designation { get; set; }
        public string Gender { get; set; }
        [StringLength(20)]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Room { get; set; }
        public DateTime StayFrom { get; set; }
        public DateTime StayTill { get; set; }
        public DateTime JoinDate { get; set; }
        public int DeptId { get; set; }
        public int Salary { get; set; }
        public int Fee { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department{ get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }

    }
}