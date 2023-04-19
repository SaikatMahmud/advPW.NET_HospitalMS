using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>,IAuth<bool>
    {
        public bool Delete(string id)
        {
            var exU = Get(id);
            db.Users.Remove(exU);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public User Update(User obj)
        {
           // var exUser = db.Users.Find(obj.Username);
            var exUser = Get(obj.Username);
            db.Entry(exUser).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Authenticate(string Username, string Password)
        {
            //var data = db.Users.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
            var data = db.Users.FirstOrDefault(u => u.Username.Equals(Username) && u.Password.Equals(Password));
            if (data != null) return true;
            return false;
        }
    }
}
