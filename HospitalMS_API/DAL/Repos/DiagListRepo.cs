using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DiagListRepo : Repo, IRepo<DiagList, int, DiagList>
    {
        public DiagList Create(DiagList obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DiagList> Get()
        {
            throw new NotImplementedException();
        }

        public DiagList Get(int id)
        {
            throw new NotImplementedException();
        }

        public DiagList Update(DiagList obj)
        {
            throw new NotImplementedException();
        }
    }
}
