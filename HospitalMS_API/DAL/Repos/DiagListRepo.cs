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
            db.DiagLists.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exDiag = Get(id);
            db.DiagLists.Remove(exDiag);
            return db.SaveChanges() > 0;
        }

        public List<DiagList> Get()
        {
            return db.DiagLists.ToList();
        }

        public DiagList Get(int id)
        {
            return db.DiagLists.Find(id);
        }

        public DiagList Update(DiagList obj)
        {
            var exDiag = Get(obj.Id);
            db.Entry(exDiag).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
