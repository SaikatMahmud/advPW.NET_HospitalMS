using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CabinRepo : Repo, IRepo<Cabin, int, Cabin>
    {
        public Cabin Create(Cabin obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cabin> Get()
        {
            throw new NotImplementedException();
        }

        public Cabin Get(int id)
        {
            throw new NotImplementedException();
        }

        public Cabin Update(Cabin obj)
        {
            throw new NotImplementedException();
        }
    }
}
