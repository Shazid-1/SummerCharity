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
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/admin/create")]
        public HttpResponseMessage Create(UserAdminDTO admin)
        {
            try
            {
                int code = AdminService.Create(admin);
                if (code == 3)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Admin Added" });
                }
                else return Request.CreateResponse(HttpStatusCode.InternalServerError, new { msg = "Admin was not Added", code });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [Route("api/admin/delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                AdminService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPatch]
        [Route("api/admin/update")]
        public HttpResponseMessage Update(AdminDTO admin)
        {
            try
            {
                AdminService.Update(admin);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
