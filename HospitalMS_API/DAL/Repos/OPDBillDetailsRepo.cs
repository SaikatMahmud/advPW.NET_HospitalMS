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
            db.OPDBillDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exOPD = Get(id);
            db.OPDBillDetails.Remove(exOPD);
            return db.SaveChanges() > 0;
        }

        public List<OPDBillDetails> Get()
        {
            return db.OPDBillDetails.ToList();
        }

        public OPDBillDetails Get(int id)
        {
            return db.OPDBillDetails.Find(id);
        }

        public OPDBillDetails Update(OPDBillDetails obj)
        {
            var exOPD = Get(obj.Id);
            db.Entry(exOPD).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
