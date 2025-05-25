using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Entidades.Core.Secciones
{
    public class SeccionSaveResponse
    {
        [JsonIgnore]
        public bool after { get; set; }
        [JsonIgnore]
        public dynamic dataProceso { get; set; }
        public bool actualizarParticipante { get; set; }

        public bool enviarCorreo { get; set; }
        public string nombreRepresentante { get; set; }
        public string codigoFirma { get; set; }
        public string correoElectronico { get; set; }
        public bool enviarCodigoFirma { get; set; }

    }

}
