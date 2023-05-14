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
    public class OPDBillDetailsController : ApiController
    {
        [HttpGet]
        [Route("api/OPDBill/Details/{opdBillId}")]
        public HttpResponseMessage Get(int opdBillId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, OPDBillDetailService.GetAllInfo(opdBillId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
