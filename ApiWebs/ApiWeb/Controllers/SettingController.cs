using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiWeb.Helpers;
using ApiWeb.Models;
using ApiWeb.ModelViews.Setting;
using ApiWeb.Transfer.Setting;
using Microsoft.Owin.Security;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using LocalizedText = ApiWeb.Helpers.AppResources;

namespace ApiWeb.Controllers
{
    [ApiWeb.Helpers.Authorize]
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/setting")]
    public class SettingController : ApiController
    {

        #region Atributos

        private SettingModel _model;

        #endregion

        #region Constructor 

        public SettingController(SettingModel pModel)
        {
            _model = pModel ?? throw new ArgumentException(nameof(pModel));
        }


        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private string IdUserAuthenticate
        {
            get
            {
                string result = string.Empty;
                var identity = (ClaimsIdentity)User.Identity;
                var idClaim = identity.Claims
                    .Where(c => c.Type == "gID")
                    .Select(c => c.Value).FirstOrDefault();
                result = idClaim;
                return result;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _model.Dispose();
                _model = null;
            }
        }


        #endregion

        #region General

        /// <summary>
        /// Crea el parametro de configuracion de aplicacion.
        /// </summary>
        /// <param name="param">Información de Parámetro de Aplicacion</param>
        /// <returns>Información de Parámetro</returns>
        /// <remarks>
        /// Registrar parámetro de aplicación
        /// </remarks>
        /// <response code="200">Operación Exitosa.</response>
        /// <response code="400">Solicitud Incorrecta.</response>        
        /// <response code="404">No Encontrado.</response>
        /// <response code="500">Error Interno de Servidor.</response>       
        [ValidateModel]
        [ResponseType(typeof(ParametroResult))]
        [HttpPost]
        [Route("parameters")]
        public async Task<IHttpActionResult> CrearParametro([FromBody] ParametroView param)
        {
            #region Validaciones

            if (param == null)
            {
                var error = LocalizedText.TodosParametrosRequerido;
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        type = KeysConfiguration.ErrorBusinessValidation,
                        message = error
                    }))
                };
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                throw new HttpResponseException(message);
            }

            #endregion

            #region Proceso


            var result = await _model.CrearParametro(param);
            if (result.HasErrors)
            {
                var error = result.Errors.FirstOrDefault();
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        type = error.Code,
                        message = error.Message
                    }))
                };
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                throw new HttpResponseException(message);
            }

            if (result.Data == null)
            {
                return NotFound();
            }
            return Ok(result.Data);

            #endregion        
        }

        #endregion


    }
}
