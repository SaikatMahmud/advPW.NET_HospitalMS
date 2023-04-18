using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OPDBillDetailsRepo : Repo, IRepo<OPDBillDetails, int, OPDBillDetails>
    {
        public OPDBillDetails Create(OPDBillDetails obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OPDBillDetails> Get()
        {
            throw new NotImplementedException();
        }

        public OPDBillDetails Get(int id)
        {
            throw new NotImplementedException();
        }

        public OPDBillDetails Update(OPDBillDetails obj)
        {
            throw new NotImplementedException();
        }
    }
}
