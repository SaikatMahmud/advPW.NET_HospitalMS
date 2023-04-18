using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WardRepo : Repo, IRepo<Ward, int, Ward>
    {
        public Ward Create(Ward obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ward> Get()
        {
            throw new NotImplementedException();
        }

        public Ward Get(int id)
        {
            throw new NotImplementedException();
        }

        public Ward Update(Ward obj)
        {
            throw new NotImplementedException();
        }
    }
}
