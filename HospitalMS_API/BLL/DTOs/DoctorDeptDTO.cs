using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDeptDTO:DoctorDTO
    {
        public DepartmentDTO Department { get; set; }
    }
}
