using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace ApiWeb.Helpers.Autenticacion.Basic
{
    public class AuthBasicModule : IHttpModule
    {
        public AuthBasicModule()
        {

        }
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;

        }
        private void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var request = new HttpRequestWrapper(application.Request);
            var headers = request.Headers;
            var authValue = headers["Authorization"];
            if (string.IsNullOrEmpty(authValue)) return;

            var scheme = authValue.Substring(0, authValue.IndexOf(' '));
            var parameter = authValue.Substring(scheme.Length).Trim();
            var credentials = ParseAuthorizationHeader(parameter);
            if (credentials == null) return;

            var user = credentials.Username;
            var password = credentials.Password;

            #region Verificacion Credenciales

            var existeUsuario = ApiKeyBasicUsuarios.UsuariosAutorizados.Any(ele => ele.Key == user && ele.Value == password);

            if (!existeUsuario) return;

            #region Add Principal Roles

            //var roles = new List<string>
            //{
            //    "admin",
            //    "regente",
            //    "af"
            //};
            //var principal = new GenericPrincipal(new GenericIdentity(user), roles.ToArray());

            #endregion

            var principal = new GenericPrincipal(new GenericIdentity(user), null);
            PutPrincipal(principal);

            #endregion

        }
        public void Dispose()
        {
            // Dispose recursos... ToDo
        }
        private Credentials ParseAuthorizationHeader(string authHeader)
        {
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader)).Split(new[] { ':' });
            if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1]))
                return null;
            return new Credentials()
            {
                Username = credentials[0],
                Password = credentials[1],
            };
        }
        private void PutPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}