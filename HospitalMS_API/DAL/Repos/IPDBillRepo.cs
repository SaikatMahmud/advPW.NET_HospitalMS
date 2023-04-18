using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class IPDBillRepo : Repo, IRepo<IPDBill, int, IPDBill>
    {
        public IPDBill Create(IPDBill obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<IPDBill> Get()
        {
            throw new NotImplementedException();
        }

        public IPDBill Get(int id)
        {
            throw new NotImplementedException();
        }

        public IPDBill Update(IPDBill obj)
        {
            throw new NotImplementedException();
        }
    }
}
