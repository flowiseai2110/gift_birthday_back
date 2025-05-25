using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Services.Productos
{
    public class ProductoImagenDto
    {
        public int productoImagenId { get; set; }
        public int productoId { get; set; }
        public int posicion { get; set; }
        public int tipoTamanio { get; set; }
        public int color { get; set; }
        public string nombreArchivo { get; set; }
        public string urlArchivo { get; set; }
        public bool activo { get; set; }
        public String? usuarioRegistro { get; set; } = "";
        public DateTime? fechaRegistro { get; set; }
        public String? usuarioModificacion { get; set; } = "";
        public DateTime? fechaModificacion { get; set; }
    }
}
