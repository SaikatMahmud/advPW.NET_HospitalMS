using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorsScheduleRepo : Repo, IRepo<DoctorsSchedule, int, DoctorsSchedule>
    {
        public DoctorsSchedule Create(DoctorsSchedule obj)
        {
            db.DoctorsSchedules.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exD = Get(id);
            db.DoctorsSchedules.Remove(exD);
            return db.SaveChanges() > 0;
        }

        public List<DoctorsSchedule> Get()
        {
            return db.DoctorsSchedules.ToList();
        }

        public DoctorsSchedule Get(int id)
        {
            return db.DoctorsSchedules.Find(id);
        }

        public DoctorsSchedule Update(DoctorsSchedule obj)
        {
            var exDoctorSchedule = Get(obj.Id);
            db.Entry(exDoctorSchedule).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
