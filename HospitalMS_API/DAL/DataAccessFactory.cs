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
        public static IRepo<Doctor, int, Doctor> DoctorData()
        {
            return new DoctorRepo();
        }  
        public static IRepo<Staff, int, Staff> StaffData()
        {
            return new StaffRepo();
        } public static IRepo<OPDBill, int, OPDBill> OPDBillData()
        {
            return new OPDBillRepo();
        } 
        public static IRepo<Department, int, Department> DepartmentData()
        {
            return new DepartmentRepo();
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
