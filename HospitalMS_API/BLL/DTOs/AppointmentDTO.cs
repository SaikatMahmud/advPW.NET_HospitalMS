using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public DateTime BookTime { get; set; }
        public string Status { get; set; }
    }
}
