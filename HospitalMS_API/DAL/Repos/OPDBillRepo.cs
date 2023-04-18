using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OPDBillRepo : Repo, IRepo<OPDBill, int, OPDBill>
    {
        public OPDBill Create(OPDBill obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OPDBill> Get()
        {
            throw new NotImplementedException();
        }

        public OPDBill Get(int id)
        {
            throw new NotImplementedException();
        }

        public OPDBill Update(OPDBill obj)
        {
            throw new NotImplementedException();
        }
    }
}
