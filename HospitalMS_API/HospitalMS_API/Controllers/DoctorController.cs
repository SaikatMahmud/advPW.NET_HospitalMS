﻿using BLL.Services;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HospitalMS_API.Filter;

namespace HospitalMS_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("api/doctor/all")]
        public HttpResponseMessage Get([FromUri] PagingModel pagingModel)
        {
            try
            {
                var source = DoctorService.Get();
                if (pagingModel == null)
                {
                    pagingModel = new PagingModel();
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page, AvailableDoctor = source.Count(x => x.IsAvailable == true)});
                }
                else
                {
                    var data = source.Skip((pagingModel.PageNumber - 1) * pagingModel.PageSize).Take(pagingModel.PageSize).ToList();
                    var page = new PaginationFilter(source.Count, pagingModel.PageSize, pagingModel.PageNumber);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Data = data, Page = page, AvailableDoctor = source.Count(x => x.IsAvailable == true) });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/doctor/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DoctorService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/doctor/add")]
        public HttpResponseMessage Add(DoctorDTO doctor)
        {
            try
            {
                var res = DoctorService.Create(doctor);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = doctor });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = doctor });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = doctor });
            }
        }
        [HttpPost]
        [Route("api/doctor/update")]
        public HttpResponseMessage Update(DoctorDTO doctor)
        {
            try
            {
                var res = DoctorService.Update(doctor);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = doctor });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = doctor });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = doctor });
            }
        }
        [HttpPost]
        [Route("api/doctor/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var res = DoctorService.Delete(id);
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
        [Route("api/doctor/deptwise")]
        public HttpResponseMessage RecepDoctorList()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DoctorService.RecepDeptWiseDoctor());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/doctor/dept/{id}")]
        public HttpResponseMessage DoctorDept(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DoctorService.DoctorOfDept(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
