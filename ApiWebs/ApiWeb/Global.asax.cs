﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using Newtonsoft.Json.Serialization;
namespace ApiWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //#region Personalizado

            //Bootstrapper.Initialise();

            //#endregion

            var config = GlobalConfiguration.Configuration;

            // La informacion siempre se retonar en Json. Ejemplo. IE.
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            #region Retornar Json en formato Camel Case

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            #endregion

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(SwaggerConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }
    }
}