using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Web.Http;

namespace ApiWeb.Controllers
{
    ////[ApiExplorerSettings(IgnoreApi = true)]
    //[Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    [RoutePrefix("api/v{version:apiVersion}/demo")]
    public class DemoController : ApiController
    {
        //[AllowAnonymous]
        [Route("ver")]
        [HttpGet]
        public IHttpActionResult Get() => Ok(new
        {
            ControllerName = GetType().Name,
            VersionApi = Request.GetRequestedApiVersion().ToString()
        });
    }

    //[Authorize]
    //[ApiVersion("2.0")]
    //[RoutePrefix("api/v{version:apiVersion}/demo")]
    //public class Demo2Controller : ApiController
    //{
    //    //[AllowAnonymous]
    //    [Route("ver")]
    //    [HttpGet]
    //    public IHttpActionResult Get() => Ok(new
    //    {
    //        ControllerName = GetType().Name,
    //        VersionApi = Request.GetRequestedApiVersion().ToString()
    //    });
    //}
}
