using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ApiWeb.Helpers.Autenticacion.Oauth
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        #region Atributos

        private readonly IServiceSeguridad _seguridad;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSeguridad"></param>
        public AuthorizationServerProvider(IServiceSeguridad pSeguridad)
        {

            _seguridad = pSeguridad ?? throw new ArgumentNullException(nameof(pSeguridad));
        }

        #endregion

        #region General

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(clientId) && !string.IsNullOrWhiteSpace(clientSecret))
                    {
                        //var res = await _seguridad.LoginApi(clientId, clientSecret);
                        //if (res.HasErrors)
                        //{
                        //    var error = res.Errors.First();
                        //    context.SetError(error.Code, error.Message);
                        //    context.Rejected();
                        //}
                        //var data = res.Element;
                        dynamic data = null;
                        if (data != null)
                        {
                            var client = new ClienteApiDto();
                            client = data;
                            context.OwinContext.Set("oauth:client", client);
                            context.Validated(clientId);
                        }
                    }
                    else
                    {
                        context.SetError(KeysConfiguration.ErrorAuthentication, AppResources.ClientCredentialHeaders);
                        context.Rejected();
                    }
                }
                catch
                {
                    context.SetError(KeysConfiguration.ErrorAuthentication, AppResources.ClientCredentialHeaders);
                    context.Rejected();
                }
            }
            else
            {
                context.SetError(KeysConfiguration.ErrorAuthentication, AppResources.ClientCredentialHeaders);
                context.Rejected();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var client = context.OwinContext.Get<ClienteApiDto>("oauth:client");
            var user = client.Usuario;
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
                identity.AddClaim(new Claim("gID", user.Id.ToString()));
                if (user.KeyRoles.Any())
                {
                    foreach (var role in user.KeyRoles.ToList())
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                }
                var props = CreateProperties(user.Id.ToString());
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var client = context.OwinContext.Get<ClienteApiDto>("oauth:client");
                if (client != null)
                {
                    var userName = context.UserName;
                    var passUser = context.Password;
                    //var resUser = await _seguridad.Login(userName, passUser);
                    //if (resUser.HasErrors)
                    //{
                    //    var error = resUser.Errors.First();
                    //    context.SetError(error.Code, error.Message);
                    //    return;
                    //}
                    dynamic user = null;
                    //var user = client.Usuario;
                    if (user != null)
                    {
                        //var userOwner = resUser.Element;
                        UsuarioDto userOwner = new UsuarioDto();
                        if (user.Id == userOwner.Id)
                        {
                            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
                            identity.AddClaim(new Claim("gID", user.Id.ToString()));
                            if (user.KeyRoles.Any())
                            {
                                foreach (var role in user.KeyRoles.ToList())
                                {
                                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                                }
                            }
                            var props = CreateProperties(user.Id.ToString());
                            var ticket = new AuthenticationTicket(identity, props);
                            context.Validated(ticket);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var mensaje = AppResources.ErrorExcepcionAplicacion;
                context.SetError(KeysConfiguration.ErrorFrameworkException, mensaje);                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Roles"></param>
        /// <returns></returns>
        public static AuthenticationProperties CreateProperties(string idCliente)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "Codigo", idCliente },
            };
            return new AuthenticationProperties(data);
        }



        #endregion

    }
}