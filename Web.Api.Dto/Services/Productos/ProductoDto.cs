using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Services.Productos
{
    public class ProductoDto
    {
        public Int32 productoId { get; set; }
        public Int32 localComercialId { get; set; }
        public String? codigoProducto { get; set; }
        public Int32 sitioPagina { get; set; }
        public Int32 categoriaId { get; set; }
        public Int32 marcaId { get; set; }
        public String nombre { get; set; } = "";
        public String descripcion { get; set; } = "";
        public String? caracteristicasDestacadas { get; set; } = "";
        public String? especificaciones { get; set; } = "";
        public String? informacionProducto { get; set; } = "";
        public Decimal precioVenta { get; set; }
        public String? estado { get; set; } = "";
        public bool activo { get; set; }
        public String? usuarioRegistro { get; set; } = "";
        public DateTime? fechaRegistro { get; set; }
        public String? usuarioModificacion { get; set; } = "";
        public DateTime? fechaModificacion { get; set; }
    }
}
