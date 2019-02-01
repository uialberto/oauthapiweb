using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiWeb.DataTransfer.DataTransferObjects.Modulos;
using ApiWeb.Helpers;
using Uibasoft.Community.Comunes.Result;

namespace ApiWeb.AppServices.Modulos.Core.Impl
{
    public partial class ServiceParametros : IServiceParametros
    {
        #region Atributos

        //private readonly IRepoParametros _repo;

        #endregion

        #region Constructor

        public ServiceParametros()
        {
            
        }
        //public ServiceParametros(IRepoParametros pRepository)
        //{
        //    _repo = pRepository ?? throw new ArgumentNullException(nameof(pRepository));
        //}

        #endregion

        #region General

        public async Task<ResultElement<ParametroDto>> Editar(ParametroDto dto)
        {
            var result = new ResultElement<ParametroDto>();
            try
            {
                //var res = await _repo.Editar(dto);
                //result = res;
            }
            catch (Exception ex)
            {
                result.AddError(KeysConfiguration.ErrorBusinessException, ex.Message);
            }
            return result;
        }

        public async Task<ResultElement<ParametroDto>> Crear(ParametroDto dto)
        {
            var result = new ResultElement<ParametroDto>();
            try
            {
                //var entity = new Parametro()
                //{
                //    Empresa = dto.Empresa,
                //    FechaProceso = dto.FechaProceso
                //};

                //var response = await _repo.Crear(entity);
                //if (response.HasErrors)
                //{
                //    result.Errors = response.Errors;
                //    return result;
                //}

                //var ele = response.Element;

                //result.Element = new ParametroDto()
                //{
                //    Empresa = ele.Empresa,
                //    FechaProceso = ele.FechaProceso
                //};


            }
            catch (Exception ex)
            {
                result.AddError(KeysConfiguration.ErrorBusinessException, ex.Message);
            }
            return result;
        }

        public ResultElement<ParametroDto> GetLastParametro()
        {
            var result = new ResultElement<ParametroDto>();
            try
            {
                //var res = _repo.GetLastParametro();
                //result = res;
            }
            catch (Exception ex)
            {
                result.AddError(KeysConfiguration.ErrorBusinessException, ex.Message);
            }
            return result;
        }

        #endregion

        #region Dispose

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;
           // _repo?.Dispose();

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}