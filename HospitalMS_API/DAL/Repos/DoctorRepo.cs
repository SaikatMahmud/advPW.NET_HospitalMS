using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorRepo : Repo, IRepo<Doctor, int, Doctor>
    {
        public Doctor Create(Doctor obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> Get()
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor Update(Doctor obj)
        {
            throw new NotImplementedException();
        }
    }
}
