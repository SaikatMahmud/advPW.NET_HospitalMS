using BLL.DTOs;
using BLL.Services;
using HospitalMS_API.Auth;
using HospitalMS_API.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HospitalMS_API.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class PatientController : ApiController
    {
        //[AdminAccess]
        [HttpGet]
        [Route("api/patient/all")]
        public HttpResponseMessage Get([FromUri] PagingModel pagingModel)
        {
            try
            {
                var source = PatientService.Get();

                if (pagingModel == null)
                {
                    pagingModel = new PagingModel();
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }
                else
                {
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }

                // return Request.CreateResponse(HttpStatusCode.OK, PatientService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/receptionist/patient/all")]
        public HttpResponseMessage PatientsOnly([FromUri] PagingModel pagingModel)
        {
            try
            {
                var source = PatientService.GetPatients();
                if (pagingModel == null)
                {
                    pagingModel = new PagingModel();
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }
                else
                {
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/patient/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, PatientService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/patient/add")]
        public HttpResponseMessage Add(PatientDTO patient)
        {
            try
            {
                var res = PatientService.Create(patient);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = patient });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = patient });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = patient });
            }
        }
        [HttpPost]
        [Route("api/patient/update")]
        public HttpResponseMessage Update(PatientDTO patient)
        {
            try
            {
                var res = PatientService.Update(patient);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = patient });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = patient });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = patient });
            }
        }
        [HttpPost]
        [Route("api/patient/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var res = PatientService.Delete(id);
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
    }
}
