using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AppointmentRepo : Repo, IRepo<Appointment, int, Appointment>
    {
        public Appointment Create(Appointment obj)
        {
            db.Appointments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exAppoi = Get(id);
            db.Appointments.Remove(exAppoi);
            return db.SaveChanges() > 0;
        }

        public List<Appointment> Get()
        {
            return db.Appointments.ToList();
        }

        public Appointment Get(int id)
        {
            return db.Appointments.Find(id);
        }

        public Appointment Update(Appointment obj)
        {
            var exAppoi = Get(obj.Id);
            db.Entry(exAppoi).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
