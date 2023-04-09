using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PatientRepo : Repo, IRepo<Patient, int, Patient>
    {
        public bool Delete(int id)
        {
            var exP = Get(id);
            db.Patients.Remove(exP);
            return db.SaveChanges() > 0;
        }

        public List<Patient> Get()
        {
            return db.Patients.ToList();
        }

        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }

        public Patient Insert(Patient obj)
        {
            db.Patients.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Patient Update(Patient obj)
        {
            var exPatient = db.Patients.Find(obj.Id);
            db.Entry(exPatient).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
