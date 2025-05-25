using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Utils;

namespace Web.Api.Dto.Gestionar.Productos
{
    public class ProductoDto
    {
        public int producto_id { get; set; }
        public string codigo_producto { get; set; }
        public int sitio_pagina { get; set; }
        public int categoria_id { get; set; }
        public int marca_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string caracteristicas_destacadas { get; set; }
        public string especificaciones { get; set; }
        public string informacion_producto { get; set; }
        public decimal precio_venta { get; set; }
        public bool activo { get; set; } 
    }

    public partial class ProductoRequestDto : PaginacionRequest
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public int categoria_id { get; set; }
        public int marca_id { get; set; }
    }
    public partial class ProductoResponseDto
    {
        public string codigo_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string caracteristicas_destacadas { get; set; }
        public string especificaciones { get; set; }
        public string informacion_producto { get; set; } 
        public decimal precio_venta { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string nombre_archivo { get; set; }
        public string url_archivo { get; set; }

    }

}
