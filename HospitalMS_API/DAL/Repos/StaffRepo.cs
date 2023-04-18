using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StaffRepo : Repo, IRepo<Staff, int, Staff>
    {
        public Staff Create(Staff obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Staff> Get()
        {
            throw new NotImplementedException();
        }

        public Staff Get(int id)
        {
            throw new NotImplementedException();
        }

        public Staff Update(Staff obj)
        {
            throw new NotImplementedException();
        }
    }
}
