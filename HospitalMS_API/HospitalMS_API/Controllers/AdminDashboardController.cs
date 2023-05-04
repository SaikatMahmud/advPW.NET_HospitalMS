using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HospitalMS_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminDashboardController : ApiController
    {
        [HttpGet]
        [Route("api/admin/dashboard")]
        public HttpResponseMessage GetAdminDash()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AdminDashboardService.DashboardInfo()); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
