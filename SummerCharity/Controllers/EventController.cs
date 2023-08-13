using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SummerCharity.Controllers
{
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("api/event/all")]
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
        [Route("api/event/{id}")]
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
        [Route("api/event/create")]
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
        [Route("api/event/delete")]
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
        [Route("api/event/update")]
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
    }
}
