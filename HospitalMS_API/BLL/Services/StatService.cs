using BLL.DTOs;
using DAL;
using iText.IO.Font;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatService
    {
        public static Dictionary<int, string> monthNames = new Dictionary<int, string>
                {
                    {1, "January"},
                    {2, "February"},
                    {3, "March"},
                    {4, "April"},
                    {5, "May"},
                    {6, "June"},
                    {7, "July"},
                    {8, "August"},
                    {9, "September"},
                    {10, "October"},
                    {11, "November"},
                    {12, "December"}
                };
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
           // fetched = fetched.OrderByDescending(x => monthNames[x.Month]).ToList();

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
            var data = DataAccessFactory.IPDAdmitData().Get();
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
            var result = fetched.Select(x => new StatDTO
            {
                DoctorName = x.DoctorName,
                OPDVisitDCount = x.Count
            }).ToList();
            return result;
        }

        public static StatDTO OPDvsIPDrv() //current month OPD IPD Revenue
        {
            var OPD = DataAccessFactory.OPDBillData().Get();
            var IPD = DataAccessFactory.IPDBillData().Get();
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var OPDrv = OPD
                        .Where(x => x.BillDate >= firstDayOfMonth && x.BillDate <= lastDayOfMonth)
                        .Select(x => x.BillAmount)
                        .Sum();
            var IPDrv = IPD
                        .Where(x => x.PaymentDate >= firstDayOfMonth && x.PaymentDate <= lastDayOfMonth)
                        .Select(x => x.TotalAmount)
                        .Sum();
            var result = new StatDTO
            {
                CurrentMnOPDrv = OPDrv,
                CurrentMnIPDrv = IPDrv
            };
            return result;
        }
    }
}
