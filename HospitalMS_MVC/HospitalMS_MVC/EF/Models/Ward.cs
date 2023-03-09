using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_MVC.EF.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BedCout { get; set; }
        public int Rent { get; set; }
        public virtual ICollection<IPDAdmit> IPDAdmits { get; set; }
        public Ward()
        {
            IPDAdmits = new List<IPDAdmit>();
        }
    }
}