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
           
            db.PerformDiags.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exDiag = Get(id);
            db.PerformDiags.Remove(exDiag);
            return db.SaveChanges() > 0;
        }

        public List<PerformDiag> Get()
        {
            return db.PerformDiags.ToList();
        }

        public PerformDiag Get(int id)
        {
            return db.PerformDiags.Find(id);
        }

        public PerformDiag Update(PerformDiag obj)
        {
            var exDiag = Get(obj.Id);
            db.Entry(exDiag).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
