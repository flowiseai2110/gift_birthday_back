using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.proceso;

namespace Web.Api.Persistence.Configuraciones
{
    public class ProductoImagenMap : IEntityTypeConfiguration<ProductoImagen>
    {
        public void Configure(EntityTypeBuilder<ProductoImagen> builder)
        {
            // table
            builder.ToTable("producto_imagen", "ecommerce");

            // key
            builder.HasKey(t => t.productoImagenId);

            // properties
            builder.Property(t => t.productoImagenId)
                .HasColumnName("i_producto_imagen_id")
                .HasColumnType("integer");

            builder.Property(t => t.productoId)
                .HasColumnName("i_producto_id")
                .HasColumnType("integer");

            builder.Property(t => t.posicion)
                .HasColumnName("i_posicion")
                .HasColumnType("integer");
             
            builder.Property(t => t.tipoTamanio)
                .HasColumnName("i_tipo_tamanio")
                .HasColumnType("integer");

            builder.Property(t => t.color)
                .HasColumnName("i_color")
                .HasColumnType("integer");

            builder.Property(t => t.nombreArchivo)
              .HasColumnName("v_nombre_archivo")
              .HasColumnType("varchar");

            builder.Property(t => t.urlArchivo)
              .HasColumnName("v_url_archivo")
              .HasColumnType("varchar"); 

            builder.Property(t => t.activo)
               .HasColumnName("b_activo")
               .HasColumnType("boolean");

            builder.Property(t => t.usuarioRegistro)
               .HasColumnName("v_usuario_registro")
               .HasColumnType("varchar");

            builder.Property(t => t.fechaRegistro)
               .HasColumnName("d_fecha_registro")
               .HasColumnType("timestamp");

            builder.Property(t => t.usuarioModificacion)
               .HasColumnName("v_usuario_modificacion")
               .HasColumnType("varchar");

            builder.Property(t => t.fechaModificacion)
               .HasColumnName("d_fecha_modificacion")
               .HasColumnType("timestamp");
        }
    }
}
