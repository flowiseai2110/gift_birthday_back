using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Entidades.Core.Secciones
{
    public class SeccionSaveRequest : BaseRequest
    {
        public Guid participanteToken { get; set; }
        public Guid moduloToken { get; set; }
        public string seccion { get; set; }
        public string requestBody { get; set; }
        public int gestorId { get; set; }
    }
}
