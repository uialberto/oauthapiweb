using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiWeb.DataTransfer.DataTransferObjects.Modulos;
using Uibasoft.Community.Comunes.Result;

namespace ApiWeb.AppServices.Modulos.Core
{
    public partial interface IServiceParametros : IDisposable
    {
        Task<ResultElement<ParametroDto>> Crear(ParametroDto dto);
        ResultElement<ParametroDto> GetLastParametro();
        Task<ResultElement<ParametroDto>> Editar(ParametroDto dto);
    }
}
