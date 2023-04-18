using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PerformDiagRepo : Repo, IRepo<PerformDiag, int, PerformDiag>
    {
        public PerformDiag Create(PerformDiag obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PerformDiag> Get()
        {
            throw new NotImplementedException();
        }

        public PerformDiag Get(int id)
        {
            throw new NotImplementedException();
        }

        public PerformDiag Update(PerformDiag obj)
        {
            throw new NotImplementedException();
        }
    }
}
