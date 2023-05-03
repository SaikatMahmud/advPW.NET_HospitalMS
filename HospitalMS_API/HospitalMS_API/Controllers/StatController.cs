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
    public class StatController : ApiController
    {
        [HttpGet]
        [Route("api/admin/stat")]
        public HttpResponseMessage GetOPDStat()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK,new {
                    OPDPtCount = StatService.GetMonthlyOPDStat(),
                    IPDPtCount= StatService.GetMonthlyIPDStat(),
                    OPDVisitDCount= StatService.OPDVisitDCount(),
                } );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
