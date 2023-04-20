using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorRepo : Repo, IRepo<Doctor, int, Doctor>
    {
        public Doctor Create(Doctor obj)
        {
            db.Doctors.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exD = Get(id);
            db.Doctors.Remove(exD);
            return db.SaveChanges() > 0;
        }

        public List<Doctor> Get()
        {
            return db.Doctors.ToList();
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public Doctor Update(Doctor obj)
        {
            var exDoctor = Get(obj.Id);
            db.Entry(exDoctor).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
