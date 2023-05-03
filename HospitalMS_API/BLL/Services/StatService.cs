using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatService
    {
        public static List<StatDTO> GetMonthlyOPDStat()
        {
            var data = DataAccessFactory.OPDBillData().Get();
            // Get the current date and the date six months ago
            DateTime currentDate = DateTime.Today;
            DateTime sixMonthsAgo = currentDate.AddMonths(-7);

            // Get the data from the database
            var fetched = data
                .Where(x => x.BillDate >= sixMonthsAgo && x.BillDate <= currentDate)
                .GroupBy(x => new { Month = x.BillDate.Month })
                .Select(g => new { Month = g.Key.Month, PatientCount = (g.Select(x => x.PatientId).Distinct().Count()) })
                .OrderByDescending(x => x.Month)
                .ToList();

            // Create the array of arrays
            //var result = fetced.Select(x => new object[] { CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month), x.PatientCount })
            //    .ToList();
            var result = fetched.Select(x => new StatDTO
            {
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month),
                OPDPtCount = x.PatientCount
            }).ToList();
            return result;
        }

        public static List<StatDTO> GetMonthlyIPDStat()
        {
            var data = DataAccessFactory.IPDAdminData().Get();
            DateTime currentDate = DateTime.Today;
            DateTime sixMonthsAgo = currentDate.AddMonths(-7);

            var fetched = data
                .Where(x => x.AdmitDate >= sixMonthsAgo && x.AdmitDate <= currentDate)
                .GroupBy(x => new { Month = x.AdmitDate.Month })
                .Select(g => new { Month = g.Key.Month, PatientCount = (g.Select(x => x.PatientId).Count()) })
                .OrderByDescending(x => x.Month)
                .ToList();
            var result = fetched.Select(x => new StatDTO
            {
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month),
                IPDPtCount = x.PatientCount
            }).ToList();
            return result;
        }

        public static List<StatDTO> OPDVisitDCount()
        {
            var data = DataAccessFactory.OPDBillDetailsData().Get();
            var fetched = data
                        .GroupBy(x => x.DoctorId)
                        .Select(g => new { DoctorId = g.Key, Count = g.Count() })
                        .Join(DataAccessFactory.DoctorData().Get(), b => b.DoctorId, d => d.Id, (b, d) => new { DoctorName = d.Name, Count = b.Count })
                        .OrderByDescending(x => x.Count)
                        .Take(7)
                        .ToList();

            //var fetched = data
            //    .Where(x => x.AdmitDate >= sixMonthsAgo && x.AdmitDate <= currentDate)
            //    .GroupBy(x => new { Month = x.AdmitDate.Month })
            //    .Select(g => new { Month = g.Key.Month, PatientCount = (g.Select(x => x.PatientId).Count()) })
            //    .OrderByDescending(x => x.Month)
            //    .ToList();
            var result = fetched.Select(x => new StatDTO
            {
                DoctorName = x.DoctorName,
                OPDVisitDCount = x.Count
            }).ToList();
            return result;
        }
    }
}
