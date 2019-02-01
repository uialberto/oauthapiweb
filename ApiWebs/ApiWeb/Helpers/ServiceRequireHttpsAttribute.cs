using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace ApiWeb.Helpers
{
    public class ServiceRequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                var error = new
                {
                    type = KeysConfiguration.ErrorServiceSecureHttps,
                    message = AppResources.ErrorServiceSecureHttps
                };
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(error))

                };
                actionContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}