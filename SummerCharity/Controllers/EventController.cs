using BLL.DTOs;
using BLL.Services;
using SummerCharity.Filters.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SummerCharity.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = EventService.Get();
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
                var data = EventService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(EventDTO admin)
        {
            try
            {
                EventService.Create(admin);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Event Added" });
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
                EventService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPatch]
        [Route("update")]
        public HttpResponseMessage Update(EventDTO admin)
        {
            try
            {
                EventService.Update(admin);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Updated" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        // FEATURES
        [HttpGet]
        [Route("date/{date}")]
        public HttpResponseMessage GetByDate(DateTime date)
        {
            try
            {
                var queryParams = Request.GetQueryNameValuePairs();
                var data = EventService.GetByDate(date, queryParams);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("title/{title}")]
        public HttpResponseMessage GetByTitle(string title)
        {
            try
            {
                var queryParams = Request.GetQueryNameValuePairs();
                var data = EventService.GetByTitle(title, queryParams);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [LoggedAdmin]
        [HttpGet]
        [Route("pending/date/{date}")]
        public HttpResponseMessage GetPendingByDate(DateTime date)
        {
            try
            {
                var data = EventService.GetPendingByDate(date);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [EnableCors("*", "*", "*")]
        [LoggedAdmin]
        [HttpGet]
        [Route("pending/title/{title}")]
        public HttpResponseMessage GetPendingByTitle(string title)
        {
            try
            {
                var data = EventService.GetPendingByTitle(title);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [LoggedCreator]
        [HttpPost]
        [Route("request")]
        public HttpResponseMessage EventRequest(EventDTO obj)
        {
            try
            {
                int code = EventService.EventRequest(obj, Request.Headers.Authorization.ToString());
                if (code == 200)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Event Requested" });
                }
                else return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = "Event Request Failed", code });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [EnableCors("*", "*", "*")]
        [LoggedAdmin]
        [HttpGet]
        [Route("pending")]
        public HttpResponseMessage PendingEvents()
        {
            try
            {
                var data = EventService.GetPendingEvent();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }
        [LoggedAdmin]
        [HttpGet]
        [Route("approve/{id}")]
        public HttpResponseMessage AdminApprove(int id)
        {
            try
            {
                var tk = Request.Headers.Authorization.ToString();
                var data = EventService.Approve(id,tk);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Event Approved"});
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
