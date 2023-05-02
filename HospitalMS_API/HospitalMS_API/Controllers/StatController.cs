using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalMS_API.Controllers
{
    public class StatController : ApiController
    {
        [HttpGet]
        [Route("api/admin/stat")]
        public HttpResponseMessage GetOPDStat()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, StatService.GetMonthlyOPDStat());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
