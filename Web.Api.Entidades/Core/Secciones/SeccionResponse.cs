using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Entidades.Core.Secciones
{
    public class SeccionResponse
    {

        public object body { get; set; }
        public bool isValid { get; set; }
        public int seccionId { get; set; }
        public bool tieneImpedimentos { get; set; } = false;
    }
}
