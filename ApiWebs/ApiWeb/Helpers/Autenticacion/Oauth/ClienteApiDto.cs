using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb.Helpers.Autenticacion.Oauth
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<string> KeyRoles { get; set; }
    }
    public class ClienteApiDto
    {
        public long Id { get; set; }
        public string Propietario { get; set; }
        public string Aplicacion { get; set; }
        public string Descripcion { get; set; }
        public string ApiClient { get; set; }
        public string ApiSecret { get; set; }
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}