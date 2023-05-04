using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CabinRepo : Repo, IRepo<Cabin, int, Cabin>
    {
        public Cabin Create(Cabin obj)
        {
            db.Cabins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exCabin = Get(id);
            db.Cabins.Remove(exCabin);
            return db.SaveChanges() > 0;
        }

        public List<Cabin> Get()
        {
            return db.Cabins.ToList();

        }

        public Cabin Get(int id)
        {
            return db.Cabins.Find(id);
        }

        public Cabin Update(Cabin obj)
        {
            var exCabin = Get(obj.Id);
            db.Entry(exCabin).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
