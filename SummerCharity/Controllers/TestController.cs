using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SummerCharity.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController

    {
        /*[HttpGet]
        [Route("test/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var event1 = EventService.Get(id);
                var data = EventDonatorService.GetEventState(event1);
                bool value = event1.EndAt < DateTime.Now;
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }*/
    }
}