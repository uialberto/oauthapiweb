using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Community.Comunes.Result;

namespace ApiWeb.AppServices.Modulos.Seguridad
{
    public interface IServiceSeguridad
    {
        ResultOperation Login(string username, string password);
    }
}
