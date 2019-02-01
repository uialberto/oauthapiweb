using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ApiWeb.Helpers
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var error = new
                {
                    type = KeysConfiguration.ErrorAuthentication,
                    message = AppResources.ErrorAutenticacion
                };
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(error))

                };
                actionContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            else
            {
                var error = new
                {
                    type = KeysConfiguration.ErrorBusinessExternalExcep,
                    message = AppResources.ErrorExcepcionAplicacion
                };
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(error))
                };
                actionContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
    }
}