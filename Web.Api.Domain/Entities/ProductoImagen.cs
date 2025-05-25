using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    [Table("producto_imagen", Schema = "ecommerce")]
    public class ProductoImagen : EntityBase
    {
        [Key]
        public int productoImagenId { get; set; }
        public int productoId { get; set; }
        public int posicion { get; set; }
        public int tipoTamanio { get; set; }
        public int color { get; set; }
        public string nombreArchivo { get; set; }     
        public string urlArchivo { get; set; }
         
    }
}
