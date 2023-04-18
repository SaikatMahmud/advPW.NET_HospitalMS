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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LeaveApplication> Get()
        {
            throw new NotImplementedException();
        }

        public LeaveApplication Get(int id)
        {
            throw new NotImplementedException();
        }

        public LeaveApplication Update(LeaveApplication obj)
        {
            throw new NotImplementedException();
        }
    }
}
