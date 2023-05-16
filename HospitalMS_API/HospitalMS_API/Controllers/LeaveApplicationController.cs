using BLL.DTOs;
using BLL.Services;
using HospitalMS_API.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace HospitalMS_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LeaveApplicationController : ApiController
    {
        [HttpGet]
        [Route("api/leaveapplication/all")]
        public HttpResponseMessage Get([FromUri] PagingModel pagingModel)
        {
            try
            {
                var source = LeaveApplicationService.Get();
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
        [Route("api/leaveapplication/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, LeaveApplicationService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/leaveapplication/approve/{id}")]
        public HttpResponseMessage ApproveApplication(int id)
        {
            try
            {
                var res = LeaveApplicationService.ApproveApplication(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Application approved" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/leaveapplication/reject/{id}")]
        public HttpResponseMessage RejectApplication(int id)
        {
            try
            {
                var res = LeaveApplicationService.RejectApplication(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Application rejected" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/leaveapplication/add")]
        public HttpResponseMessage Add(LeaveApplicationDTO obj)
        {
            try
            {
                var token = Request.Headers.Authorization.ToString();
                obj.StaffId = AuthService.TokenUserId(token.ToString());

                var res = LeaveApplicationService.Create(obj);
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
        [Route("api/leaveapplication/update")]
        public HttpResponseMessage Update(LeaveApplicationDTO obj)
        {
            try
            {
                var res = LeaveApplicationService.Update(obj);
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
        //[HttpPost]
        //[Route("api/staff/delete/{id}")]
        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        var res = StaffService.Delete(id);
        //        if (res)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete Success" });
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Delete failed" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
        //    }
        //}
    }
}

