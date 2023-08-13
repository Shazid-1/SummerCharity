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
    public class EventDonatorController : ApiController
    {
        [HttpGet]
        [Route("api/event/donator/all")]
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
        [Route("api/event/donator/{id}")]
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
        [Route("api/event/donator/create")]
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
        [Route("api/event/donator/delete")]
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
        [Route("api/event/donator/update")]
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
    }
}
