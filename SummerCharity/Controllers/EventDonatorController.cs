using BLL.DTOs;
using BLL.Services;
using SummerCharity.Filters.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SummerCharity.Controllers
{
    [RoutePrefix("api/eventdonator")]
    public class EventDonatorController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = EventDonatorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = EventDonatorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(EventDonatorDTO admin)
        {
            try
            {
                EventDonatorService.Create(admin);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Added" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                EventDonatorService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPatch]
        [Route("update")]
        public HttpResponseMessage Update(EventDonatorDTO admin)
        {
            try
            {
                EventDonatorService.Update(admin);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Updated" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        // FEATURES
        [LoggedDonator]
        [HttpPost]
        [Route("donate")]
        public HttpResponseMessage Donate(EventDonatorDTO obj)
        {
            try
            {
                int code = EventDonatorService.Donate(obj, Request.Headers.Authorization.ToString());
                if (code == 200)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Donated" });
                }
                else return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = "Donation Failed", code });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
