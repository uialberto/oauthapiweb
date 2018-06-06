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

namespace ApiWeb
{
    public partial class Startup
    {
        private void ConfigureOAuth(IAppBuilder app, IServiceSeguridad pSeguridad)
        {

            #region UseOAuthBearerAuthentication

            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            };

            var ApiOauthOptions = GetOptionsApi(pSeguridad);
            //var webOauthOptions = GetOptionsWeb(pSeguridad);

            app.UseOAuthAuthorizationServer(ApiOauthOptions);
            //app.UseOAuthAuthorizationServer(webOauthOptions);

            app.UseOAuthBearerAuthentication(authOptions);

            #endregion

        }

        private OAuthAuthorizationServerOptions GetOptionsApi(IServiceSeguridad service)
        {
            //var value = KeysConfiguration.KeyTokenApiExpireMin;
            var result = new OAuthAuthorizationServerOptions()
            {
                //AllowInsecureHttp = KeysConfiguration.KeyApiUseHttp,
                //TokenEndpointPath = new PathString(KeysConfiguration.KeyTokenApiUrl),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                Provider = new AuthorizationServerProvider(service),
                //RefreshTokenProvider = new RefreshTokenProvider()
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