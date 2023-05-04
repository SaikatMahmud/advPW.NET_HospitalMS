using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OPDBill
    {
        public int Id { get; set; }
        public int BillAmount { get; set; }
        [Required]
        public int PaidAmount { get; set; }
        // public int Discount { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; }
        public DateTime BillDate { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<OPDBillDetails> OPDBillDetails { get; set; }
        public OPDBill()
        {
            OPDBillDetails = new List<OPDBillDetails>();
        }
    }
}
