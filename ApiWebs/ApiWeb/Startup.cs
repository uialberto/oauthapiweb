using ApiWeb.AppServices.Modulos.Seguridad;
using ApiWeb.AppServices.Modulos.Seguridad.Impl;
using ApiWeb.Helpers.Autenticacion;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Owin;

[assembly: OwinStartup(typeof(ApiWeb.Startup))]
namespace ApiWeb
{
    public partial class Startup
    {
        public Startup()
        {
        }
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new ServiceSeguridad());
            ConfigureOAuth(app);
        }
    }
}
