using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PrescriptionRepo : Repo, IRepo<Prescription, int, Prescription>
    {
        public Prescription Create(Prescription obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> Get()
        {
            throw new NotImplementedException();
        }

        public Prescription Get(int id)
        {
            throw new NotImplementedException();
        }

        public Prescription Update(Prescription obj)
        {
            throw new NotImplementedException();
        }
    }
}
