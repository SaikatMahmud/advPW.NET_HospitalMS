using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public DateTime BookTime { get; set; }
        public int Fee { get; set; }
        public string Status { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}
