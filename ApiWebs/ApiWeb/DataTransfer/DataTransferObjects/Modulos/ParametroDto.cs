using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uibasoft.Community.TransferDtos.Entities;

namespace ApiWeb.DataTransfer.DataTransferObjects.Modulos
{
    public partial class ParametroDto : EntityDto
    {
        public string Empresa { get; set; }
        public DateTime FechaProceso { get; set; }
    }
}