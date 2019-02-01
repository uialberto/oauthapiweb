using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiWeb.AppServices.Modulos.Core;
using ApiWeb.DataTransfer.DataTransferObjects.Modulos;
using ApiWeb.ModelViews.Setting;
using ApiWeb.Transfer;
using ApiWeb.Transfer.Setting;

namespace ApiWeb.Models
{
    public class SettingModel : IDisposable
    {
        #region Atributos

        protected readonly IServiceParametros AppParametros;

        #endregion

        #region Constructor

        public SettingModel(IServiceParametros pAppParametros)
        {
            AppParametros = pAppParametros ?? throw new ArgumentNullException(nameof(pAppParametros));
        }

        #endregion

        #region General

        public async Task<ResultData<ParametroResult>> CrearParametro(ParametroView param)
        {
            var result = new ResultData<ParametroResult>();

            var res = await AppParametros.Crear(new ParametroDto()
            {
                Empresa = param.Empresa,
                FechaProceso = param.FechaProceso
            });

            if (res.HasErrors)
            {
                result.Errors = res.Errors;
                return result;
            }
            var ele = res.Element;
            if (ele != null)
            {
                result.Data = new ParametroResult()
                {
                    Id = ele.Id,
                    Empresa = ele.Empresa,
                    FechaProceso = ele.FechaProceso
                };
            }
            return result;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            AppParametros?.Dispose();
        }

        #endregion
    }
}