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
    [RoutePrefix("api/donator")]
    public class DonatorController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DonatorService.Get();
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
                var data = DonatorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(UserDonatorDTO donator)
        {
            try
            {
                int code = DonatorService.Create(donator);
                if (code == 3)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Donator Added" });
                }
                else return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = "Donator was not Added", code });
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
                DonatorService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPatch]
        [Route("update")]
        public HttpResponseMessage Update(DonatorDTO donator)
        {
            try
            {
                DonatorService.Update(donator);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Updated" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        // FEATURES
        [LoggedDonator]
        [HttpGet]
        [Route("history")]
        public HttpResponseMessage History()
        {
            try
            {
                var data = DonatorService.History(Request.Headers.Authorization.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
