using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HospitalMS_API.Auth
{
    public class AdminAccess : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (AuthService.TokenUserType(token.ToString()) != "Admin")
            {
                actionContext.Response =
                  actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized,
                  new { Msg = "Supplied token has no Admin access" });
            }
            base.OnAuthorization(actionContext);
        }
    }
}