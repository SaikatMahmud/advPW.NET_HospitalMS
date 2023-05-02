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
            DateTime sixMonthsAgo = currentDate.AddMonths(-6);

            // Get the data from the database
            var fetched = data
                .Where(x => x.BillDate >= sixMonthsAgo && x.BillDate <= currentDate)
                .GroupBy(x => new { Month = x.BillDate.Month })
                .Select(g => new { Month = g.Key.Month, PatientCount = (g.Select(x => x.PatientId).Distinct().Count()) })
                .OrderBy(x => x.Month)
                .ToList();

            // Create the array of arrays
            //var result = fetced.Select(x => new object[] { CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month), x.PatientCount })
            //    .ToList();
            var result = fetched.Select(x => new StatDTO
            {
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month),
                PatientCount = x.PatientCount
            }).ToList();
            return result;
        }
    }
}
