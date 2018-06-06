using ApiWeb.Helpers.Autenticacion;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ApiWeb.Startup))]
namespace ApiWeb
{
    public partial class Startup
    {
        private readonly IServiceSeguridad _seg;
        public Startup()
        {
            //var pSeguridad = IoC.Container.Resolver<IServiceSeguridad>();
            //_seg = pSeguridad ?? throw new ArgumentNullException(nameof(pSeguridad));
        }
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext(() => new AppUnitOfWork());
            ConfigureOAuth(app, _seg);
        }
    }
}
