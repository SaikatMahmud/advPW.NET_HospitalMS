using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DoctorsSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string SlotTime { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
