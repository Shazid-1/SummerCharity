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
    public class CreatorController : ApiController
    {
        [HttpGet]
        [Route("api/creator/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CreatorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/creator/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = CreatorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/creator/create")]
        public HttpResponseMessage Create(CreatorDTO creator)
        {
            try
            {
                CreatorService.Create(creator);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Creator Added" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [Route("api/creator/delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                CreatorService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch]
        [Route("api/creator/update")]
        public HttpResponseMessage Update(CreatorDTO c)
        {
            try
            {
                CreatorService.Update(c);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Updated" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
