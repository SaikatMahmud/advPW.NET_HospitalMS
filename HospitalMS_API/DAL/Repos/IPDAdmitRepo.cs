using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class IPDAdmitRepo   :Repo, IRepo<IPDAdmit, int, IPDAdmit>
    {
        public IPDAdmit Create(IPDAdmit obj)
        {
            db.IPDAdmits.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exIPD = Get(id);
            db.IPDAdmits.Remove(exIPD);
            return db.SaveChanges() > 0;
        }

        public List<IPDAdmit> Get()
        {
            return db.IPDAdmits.ToList();
        }

        public IPDAdmit Get(int id)
        {
            return db.IPDAdmits.Find(id);
        }

        public IPDAdmit Update(IPDAdmit obj)
        {
            var exIPD = Get(obj.Id);
            db.Entry(exIPD).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
