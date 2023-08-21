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
    [RoutePrefix("api/membershipcreator")]
    [LoggedAdmin]
    public class MembershipCreatorController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = MembershipCreatorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = MembershipCreatorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(MembershipCreatorDTO obj)
        {
            try
            {
                var data = MembershipCreatorService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(MembershipCreatorDTO obj)
        {
            try
            {
                var data = MembershipCreatorService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = MembershipCreatorService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        //remember to annote loggedAdmin
        [HttpGet]
        [Route("approve/{cid}")]
        public HttpResponseMessage Approve(int cid)
        {
            try
            {
                var tk = Request.Headers.Authorization.ToString();
                var data = MembershipCreatorService.MembershipApprove(cid, tk);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Membership Approved" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}