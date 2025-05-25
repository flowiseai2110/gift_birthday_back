using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;

namespace Web.Api.Persistence.Configuraciones
{
    public class CartillaMap : IEntityTypeConfiguration<Cartilla>
    {
        public void Configure(EntityTypeBuilder<Cartilla> builder)
        {
            // table
            builder.ToTable("cartilla", "proceso");

            // key
            builder.HasKey(t => t.cartilla_id);

            // properties
            builder.Property(t => t.cartilla_id)
                .HasColumnName("i_cartilla_id")
                .HasColumnType("integer");

            builder.Property(t => t.local_comercial_id)
                .HasColumnName("i_local_comercial_id")
                .HasColumnType("integer");

            builder.Property(t => t.codigo)
                .HasColumnName("v_codigo")
                .HasColumnType("varchar");

            builder.Property(t => t.titulo)
                .HasColumnName("v_titulo")
                .HasColumnType("varchar");

            builder.Property(t => t.descripcion)
                .HasColumnName("v_descripcion")
                .HasColumnType("varchar");

            builder.Property(t => t.cantidad_sello)
                .HasColumnName("i_cantidad_sello")
                .HasColumnType("integer");

            builder.Property(t => t.cantidad_promocion)
              .HasColumnName("i_cantidad_promocion")
              .HasColumnType("integer");

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
