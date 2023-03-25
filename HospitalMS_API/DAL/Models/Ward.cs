using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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
