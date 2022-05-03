using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace AuthorizationFilterMVC_API_Demo.Controllers
{
    [RoutePrefix("api/TestAuth")]
    public class TestAuthController : ApiController
    {
        // GET: TestAuth
        [HttpGet]
        public JsonResult<string> Index()
        {
            return Json("This is Index");
        }

        [HttpGet]
        [Route(nameof(IsAuth))]
        [CustomAuth]
        public JsonResult<string[]> IsAuth()
        {
            return Json(new string[] { "value1", "value2" });
        }
    }
}