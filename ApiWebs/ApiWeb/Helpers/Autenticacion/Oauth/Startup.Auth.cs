using ApiWeb.Helpers.Autenticacion;
using ApiWeb.Helpers.Autenticacion.Oauth;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiWeb.AppServices.Modulos.Seguridad;
using ApiWeb.Helpers;

namespace ApiWeb
{
    public partial class Startup
    {
        private void ConfigureOAuth(IAppBuilder app)
        {

            #region UseOAuthBearerAuthentication

            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            };

            var ApiOauthOptions = GetOptionsApi();
            //var webOauthOptions = GetOptionsWeb(pSeguridad);

            app.UseOAuthAuthorizationServer(ApiOauthOptions);
            //app.UseOAuthAuthorizationServer(webOauthOptions);

            app.UseOAuthBearerAuthentication(authOptions);

            #endregion

        }

        private OAuthAuthorizationServerOptions GetOptionsApi()
        {
            var value = KeysConfiguration.KeyAccessTokenExpireMin;
            var result = new OAuthAuthorizationServerOptions()
            {
                //AllowInsecureHttp = KeysConfiguration.KeyApiUseHttp,
                TokenEndpointPath = new PathString(KeysConfiguration.KeyTokenUrl),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(value),
                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            };
            return result;
        }

        //private OAuthAuthorizationServerOptions GetOptionsWeb(IServiceSeguridad service)
        //{
        //    var value = KeysConfiguration.KeyTokenApiExpireMin;
        //    var result = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = KeysConfiguration.KeyApiUseHttp,
        //        TokenEndpointPath = new PathString(KeysConfiguration.KeyTokenWebUrl),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(value),
        //        Provider = new WebAuthorizationServerProvider(service),
        //        RefreshTokenProvider = new RefreshTokenProvider()
        //    };
        //    return result;
        //}
    }
}