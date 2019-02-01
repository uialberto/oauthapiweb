using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace ApiWeb.Helpers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                var mstate = actionContext.ModelState;
                var errores = mstate?.Values?.Select(ele => ele.Errors.First().ErrorMessage).ToList();
                var literalizeErrors = AppResources.ParametrosRequerido;
                if (errores.Any(ele => !string.IsNullOrWhiteSpace(ele)))
                {
                    literalizeErrors = string.Join(",", errores);
                }
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        type = KeysConfiguration.ErrorBusinessValidation,
                        message = literalizeErrors
                    }))
                };
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                actionContext.Response = message;


            }
        }
    }
}