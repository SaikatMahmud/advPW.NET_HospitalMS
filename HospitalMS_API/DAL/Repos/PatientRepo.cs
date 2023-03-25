using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PatientRepo
    {
        public static HMSDb db;
        static PatientRepo()
        {
            db = new HMSDb();
        }
        public static List<Patient> Get()
        {
            return db.Patients.ToList();
        }
        public static Patient Get(int id)
        {
            return db.Patients.Find(id);
        }
        public static bool Create(Patient patient)
        {
            db.Patients.Add(patient);
            return db.SaveChanges() > 0;
        }
        public static bool Update(Patient patient)
        {
            var exPatient = db.Patients.Find(patient.Id);
            db.Entry(exPatient).CurrentValues.SetValues(patient);
            return db.SaveChanges()>0;
        }
    }
}
