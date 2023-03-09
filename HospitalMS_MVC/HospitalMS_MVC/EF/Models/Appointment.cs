using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime ScheduleTime { get; set; }
        public DateTime BookTime { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}