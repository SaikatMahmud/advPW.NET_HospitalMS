using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class IPDAdmitRepo : Repo, IRepo<IPDAdmit, int, IPDAdmit>
    {
        public IPDAdmit Create(IPDAdmit obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<IPDAdmit> Get()
        {
            throw new NotImplementedException();
        }

        public IPDAdmit Get(int id)
        {
            throw new NotImplementedException();
        }

        public IPDAdmit Update(IPDAdmit obj)
        {
            throw new NotImplementedException();
        }
    }
}
