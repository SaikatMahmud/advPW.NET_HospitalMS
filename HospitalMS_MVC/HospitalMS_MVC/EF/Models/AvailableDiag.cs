using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class AvailableDiag // available diagnosis in the hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DeptId { get; set; }
    }
}