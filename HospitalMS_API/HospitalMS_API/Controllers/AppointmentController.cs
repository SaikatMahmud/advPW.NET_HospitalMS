using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HospitalMS_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AppointmentController : ApiController
    {
        [HttpGet]
        [Route("api/appointment/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AppointmentService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/appointment/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AppointmentService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/appointment/add")]
        public HttpResponseMessage Add(AppointmentDTO obj)
        {
            try
            {
                var res = AppointmentService.Create(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = obj });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }
        }

        [HttpPost]
        [Route("api/appointment/update")]
        public HttpResponseMessage Update(AppointmentDTO obj)
        {
            try
            {
                var res = AppointmentService.Update(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = obj });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = obj });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = obj });
            }
        }

        [HttpGet]
        [Route("api/appointment/cancel/{id}")]
        public HttpResponseMessage CancelAppointment(int id)
        {
            try
            {
                var res = AppointmentService.CancelAppointment(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Appointment cancelled"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/appointment/close/{id}")]
        public HttpResponseMessage CloseAppointment(int id)
        {
            try
            {
                var res = AppointmentService.CloseAppointment(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Appointment closed" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/appointment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var res = AppointmentService.Delete(id);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Success" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Delete failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/appointment/available/{doctorId}/{date}")]
        public HttpResponseMessage AvailableSlots(int doctorId, DateTime date)
        {
            try
            {
                var res = AppointmentService.AvailableSlot(doctorId, date);

                return Request.CreateResponse(HttpStatusCode.OK, new { AvailableTimes = res });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/appointment/print/{id}")]
        public HttpResponseMessage Pdf(int id)
        {
            try
            {
                var content = AppointmentService.PrintAppointment(id);
                if (content != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(content);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                    {
                        FileName = "appointment_" + id + ".pdf",
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


        // PDF genration testing commented
        //    [HttpGet]
        //    [Route("api/appointment/print/{id}")]
        //    public HttpResponseMessage Pdf(int id)
        //    {
        //        try
        //        {
        //            var content = RenderTestService.GetPDF("appointment_"+id);
        //            if (content != null)
        //            {
        //                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //                response.Content = new ByteArrayContent(content);
        //                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
        //                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
        //                {
        //                    FileName = "MyPDF.pdf",
        //                };
        //                return response;
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Could not generate pdf now" });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });

        //        }
        //        //var content = RenderTestService.GetPDF();

        //        //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

        //        //// Set the Content of the HttpResponseMessage to a ByteArrayContent object containing the PDF bytes
        //        //response.Content = new ByteArrayContent(content);

        //        //// Set the Content-Type header of the HttpResponseMessage to application/pdf
        //        //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
        //        //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
        //        //{
        //        //    FileName = "MyPDF.pdf",

        //        //};
        //        //// Return the HttpResponseMessage
        //        //return response;

        //        //var pdfMemoryStream = RenderTestService.GetPDF();
        //        //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //        //response.Content = new StreamContent(pdfMemoryStream);
        //        //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        //        //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //        //{
        //        //    FileName = "MyPDF.pdf"
        //        //};
        //        // return httpResponseMessage;

        //        //try
        //        //{
        //        //    var res = RenderTestService.GetPDF();
        //        //    if (res != null)
        //        //    {
        //        //        return Request.CreateResponse(HttpStatusCode.OK, new { File(res, "application/pdf", "MyPDF.pdf");
        //        //    });
        //        //    }
        //        //    else
        //        //    {
        //        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Delete failed" });
        //        //    }
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
        //        //}
        //    }
        //}
    }
}
