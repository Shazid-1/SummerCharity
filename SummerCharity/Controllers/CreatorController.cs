﻿using BLL.DTOs;
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
    [RoutePrefix("api/creator")]
    public class CreatorController : ApiController
    {
        [HttpGet]
        [Route("all")]
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
        [Route("get/{id}")]
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
        [Route("create")]
        public HttpResponseMessage Create(UserCreatorDTO creator)
        {
            try
            {
                int code = CreatorService.Create(creator);
                if (code == 200)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Creator Added" });
                }
                else return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = "Creator was not Added", code });
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
                CreatorService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPatch]
        [Route("update")]
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
        // FEATURES
        [LoggedCreator]
        [HttpGet]
        [Route("history")]
        public HttpResponseMessage History()
        {
            try
            {
                var data = CreatorService.History(Request.Headers.Authorization.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
