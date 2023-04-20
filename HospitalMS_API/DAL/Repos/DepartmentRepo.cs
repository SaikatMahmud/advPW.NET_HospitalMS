using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DepartmentRepo : Repo, IRepo<Department, int, Department>
    {
        public Department Create(Department obj)
        {
            db.Departments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var exDept = Get(id);
            db.Departments.Remove(exDept);
            return db.SaveChanges() > 0;
        }

        public List<Department> Get()
        {
            return db.Departments.ToList();
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public Department Update(Department obj)
        {
            var exDept = Get(obj.Id);
            db.Entry(exDept).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
