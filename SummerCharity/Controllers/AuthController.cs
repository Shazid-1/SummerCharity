using BLL.Services;
using SummerCharity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SummerCharity.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginModel data)
        {
            List<CookieHeaderValue> cookie = Request.Headers.GetCookies().ToList();
            var token = AuthService.Login(data.Username, data.Password);
            if (token != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, token);
                var cookie1 = new CookieHeaderValue("sc-key", token.Key);
                cookie1.Domain = "127.0.0.1";
                cookie1.Path = "/";
                cookie1.Expires = token.ExpiredAt;
                response.Headers.AddCookies(new[] { cookie1 });
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User not found", token });
            }
        }
    }
}