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
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            // table
            builder.ToTable("producto", "ecommerce");

            // key
            builder.HasKey(t => t.productoId);

            // properties
            builder.Property(t => t.productoId)
                .HasColumnName("i_producto_id")
                .HasColumnType("integer");
            
            builder.Property(t => t.localComercialId)
                .HasColumnName("i_local_comercial_id")
                .HasColumnType("integer");

            builder.Property(t => t.codigoProducto)
                .HasColumnName("v_codigo_producto")
                .HasColumnType("varchar");

            builder.Property(t => t.sitioPagina)
                .HasColumnName("i_sitio_pagina")
                .HasColumnType("integer");

            builder.Property(t => t.categoriaId)
                .HasColumnName("i_categoria_id")
                .HasColumnType("integer");

            builder.Property(t => t.marcaId)
                .HasColumnName("i_marca_id")
                .HasColumnType("integer");

            builder.Property(t => t.nombre)
                .HasColumnName("v_nombre")
                .HasColumnType("varchar");

            builder.Property(t => t.descripcion)
              .HasColumnName("v_descripcion")
              .HasColumnType("varchar");

            builder.Property(t => t.caracteristicasDestacadas)
              .HasColumnName("v_caracteristicas_destacadas")
              .HasColumnType("varchar");

            builder.Property(t => t.especificaciones)
              .HasColumnName("v_especificaciones")
              .HasColumnType("varchar");

            builder.Property(t => t.informacionProducto)
              .HasColumnName("v_informacion_producto")
              .HasColumnType("varchar");

            builder.Property(t => t.precioVenta)
               .HasColumnName("f_precio_venta")
               .HasColumnType("decimal");

            builder.Property(t => t.estado)
                .HasColumnName("v_estado")
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
