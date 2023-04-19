using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Patient, int, Patient> PatientData()
        {
            return new PatientRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token,string,Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
    }
}
