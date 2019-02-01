using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uibasoft.Community.Comunes.Result;

namespace ApiWeb.Transfer
{
    /// <summary>
    /// Resultado de la acción.
    /// </summary>    
    public class ResultData<T> : ResultOperation
    {
        public ResultData()
        {

        }
        /// <summary>
        /// Información de retorno.
        /// </summary>
        public T Data { get; set; }
    }
    public class ResultData : ResultOperation
    {
        public ResultData()
        {

        }
        public object Data { get; set; }
    }
}