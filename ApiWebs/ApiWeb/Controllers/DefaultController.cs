using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiWeb.Controllers
{
    [RoutePrefix("default")]
    public partial class DefaultController : AsyncController
    {
        // GET: Default
        [Route("index")]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
