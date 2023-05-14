using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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


        [HttpGet]
        [Route("api/OPDBillDetails/print/{opdBillId}")]
        public HttpResponseMessage Pdf(int opdBillId)
        {
            try
            {
                var content = OPDBillDetailService.PrintOPDBillDetails(opdBillId);
                if (content != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(content);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = "OPD_Bill" + opdBillId + ".pdf",
                    };
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Could not generate pdf now" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });

            }
        }
    }
}
