using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LeaveApplicationRepo : Repo, IRepo<LeaveApplication, int, LeaveApplication>
    {
        public LeaveApplication Create(LeaveApplication obj)
        {
            db.LeaveApplications.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exLeave = Get(id);
            db.LeaveApplications.Remove(exLeave);
            return db.SaveChanges() > 0;
        }

        public List<LeaveApplication> Get()
        {
            return db.LeaveApplications.ToList();
        }

        public LeaveApplication Get(int id)
        {
            return db.LeaveApplications.Find(id);
        }

        public LeaveApplication Update(LeaveApplication obj)
        {
            var exLeave = Get(obj.Id);
            db.Entry(exLeave).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
