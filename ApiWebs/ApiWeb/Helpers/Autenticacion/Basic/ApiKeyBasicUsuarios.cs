using System.Collections.Generic;

namespace ApiWeb.Helpers.Autenticacion.Basic
{
    public class ApiKeyBasicUsuarios
    {
        private static Dictionary<string, string> _keyAutorize;

        public static Dictionary<string, string> UsuariosAutorizados
        {
            get
            {
                // Para crear usuario y password use el algoritmo SHA1 (http://www.sha1-online.com/), y comparte estos credenciales con terceeros. 

                // [Uibasoft] {Usuario: uibasoft, Password: *campeon*} = {f09551fe5f6189f34e67b169e377086af1e6faf7,cbc9f1d1b7a0668d5e2d905968f772cff238cd44}  

                if (_keyAutorize != null)
                    return _keyAutorize;

                _keyAutorize = new Dictionary<string, string>
                {
                    {"f09551fe5f6189f34e67b169e377086af1e6faf7", "cbc9f1d1b7a0668d5e2d905968f772cff238cd44"},
                };
                return _keyAutorize;

            }
        }
    }
}