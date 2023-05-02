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
            db.IPDBills.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exIPD = Get(id);
            db.IPDBills.Remove(exIPD);
            return db.SaveChanges() > 0;
        }

        public List<IPDBill> Get()
        {
            return db.IPDBills.ToList();
        }

        public IPDBill Get(int id)
        {
            return db.IPDBills.Find(id);
        }

        public IPDBill Update(IPDBill obj)
        {
            var exIPD = Get(obj.Id);
            db.Entry(exIPD).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
