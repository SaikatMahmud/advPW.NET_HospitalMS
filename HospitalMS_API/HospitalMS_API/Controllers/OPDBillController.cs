using BLL.DTOs;
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
    public class OPDBillController : ApiController
    {

        [HttpPost]
        [Route("api/OPDBill/add")]
        public HttpResponseMessage Add(OPDBillDTO obj)
        {
            try
            {
                var res = OPDBillService.Create(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Bill created", Data = obj});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Bill can not be created", Data = obj });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }
        }

    }
}