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
            db.OPDBills.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exOPD = Get(id);
            db.OPDBills.Remove(exOPD);
            return db.SaveChanges() > 0;
        }

        public List<OPDBill> Get()
        {
            return db.OPDBills.ToList();
        }

        public OPDBill Get(int id)
        {
            return db.OPDBills.Find(id);
        }

        public OPDBill Update(OPDBill obj)
        {
            var exOPD = Get(obj.Id);
            db.Entry(exOPD).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
