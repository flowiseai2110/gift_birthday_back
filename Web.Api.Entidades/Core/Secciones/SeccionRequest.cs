using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Entidades.Core.Secciones
{
    public class SeccionRequest : BaseRequest
    {
        public Guid participanteToken { get; set; }
        public Guid moduloToken { get; set; }
        public string seccion { get; set; }

    }
}
