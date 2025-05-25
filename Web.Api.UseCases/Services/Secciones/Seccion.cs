 
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.UseCases.Services.Secciones
{
    public class Seccion
    {
        public Guid participanteToken { get; set; }
        public int personaId { get; set; }
        public int gestorId { get; set; }
        public int modalidadId { get; set; }
        public string body { get; set; }
        public int seccionId { get; set; }
        public int pasoOrden { get; set; }
        public int seccionOrden { get; set; }
        public bool validacionPrevia { get; set; }
        public bool forzarValidacion { get; set; }
        public bool mantenerSeccion { get; set; } 
    }
}
