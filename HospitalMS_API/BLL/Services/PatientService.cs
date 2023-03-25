using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService
    {
        public static object Get()
        {
            return PatientRepo.Get();
        }
        public static object Get(int id)
        {
            return PatientRepo.Get(id);
        }
        public static bool Create(Patient patient)
        {
            return PatientRepo.Create(patient);
        }
        public static bool Update(Patient patient)
        {
            return PatientRepo.Update(patient);
        }
    }
}
