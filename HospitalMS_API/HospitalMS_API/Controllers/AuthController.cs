using BLL.Services;
using HospitalMS_API.Auth;
using HospitalMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace HospitalMS_API.Controllers
{
    [EnableCors("*","*","*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var token = AuthService.Authenticate(login.Username, login.Password);
                if (token != null)
                {
                    var userType = AuthService.TokenUserType(token.TKey.ToString());
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Authenticated", Data = token,userType });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or Password invalid", Data = login });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = login });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                var res = AuthService.Logout(Request.Headers.Authorization.ToString());
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Logout Success"});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Logout not success" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
