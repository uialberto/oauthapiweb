using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiWeb.Helpers;
using Uibasoft.Community.Comunes.Result;

namespace ApiWeb.AppServices.Modulos.Seguridad.Impl
{
    public class ServiceSeguridad : IServiceSeguridad
    {
        public ServiceSeguridad()
        {

        }

        public ResultOperation Login(string username, string password)
        {
            var result = new ResultOperation();
            try
            {

                //var path = KeysConfiguration.KeyFilePathUser;
                //var root = XElement.Load(path);
                //var usuario = (from u in root.Elements("usuario")
                //               where (u.Element("username")?.Value)?.ToLower() == username.ToLower()
                //               select new UsuarioDto
                //               {
                //                   Id = string.IsNullOrWhiteSpace(u.Attribute("id")?.Value) ? string.Empty : u.Attribute("id")?.Value,
                //                   KeyDepartamento = string.IsNullOrWhiteSpace(u.Attribute("keyCodeDepartamento")?.Value) ? string.Empty : u.Attribute("keyCodeDepartamento")?.Value,
                //                   EsRoot = string.IsNullOrWhiteSpace(u.Attribute("esRoot")?.Value) ? false : bool.Parse(u.Attribute("esRoot").Value),
                //                   Nombres = string.IsNullOrWhiteSpace(u.Element("nombres")?.Value) ? string.Empty : u.Element("nombres").Value,
                //                   Apellidos = string.IsNullOrWhiteSpace(u.Element("apellidos")?.Value) ? string.Empty : u.Element("apellidos").Value,
                //                   Username = string.IsNullOrWhiteSpace(u.Element("username")?.Value) ? string.Empty : u.Element("username").Value,
                //                   Password = string.IsNullOrWhiteSpace(u.Element("password")?.Value) ? string.Empty : u.Element("password").Value,
                //               }).ToList().FirstOrDefault();

                //if (usuario != null)
                //{
                //    var passHash = usuario.Password;
                //    var validPass = false;
                //    var cipher = IoC.Resolver<IPasswordCipher>();
                //    if (cipher != null)
                //    {
                //        validPass = cipher.ValidatePassword(password, passHash);
                //    }
                //    if (!validPass)
                //    {
                //        result.AddError(KeysConfiguration.ErrorAuthentication, LocalizedText.ErrorLogin);
                //        return result;
                //    }
                //}

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                result.AddError(KeysConfiguration.ErrorBusinessException, mensaje);
            }

            return result;
        }
    }
}