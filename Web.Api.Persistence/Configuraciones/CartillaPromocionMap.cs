using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.proceso;

namespace Web.Api.Persistence.Configuraciones
{
    public class CartillaPromocionMap : IEntityTypeConfiguration<CartillaPromocion>
    {
        public void Configure(EntityTypeBuilder<CartillaPromocion> builder)
        {
            // table
            builder.ToTable("cartilla_promocion", "proceso");

            // key
            builder.HasKey(t => t.cartilla_promocion_id);

            // properties
            builder.Property(t => t.cartilla_promocion_id)
                .HasColumnName("i_cartilla_promocion_id")
                .HasColumnType("integer");

            builder.Property(t => t.cartilla_id)
                .HasColumnName("i_cartilla_id")
                .HasColumnType("integer");

            builder.Property(t => t.promocion_id)
               .HasColumnName("i_promocion_id")
               .HasColumnType("integer");

            builder.Property(t => t.local_comercial_id)
             .HasColumnName("i_local_comercial_id")
             .HasColumnType("integer");


            builder.Property(t => t.fecha_promocion_inicio)
               .HasColumnName("d_fecha_promocion_inicio")
               .HasColumnType("timestamp");


            builder.Property(t => t.fecha_promocion_fin)
               .HasColumnName("d_fecha_promocion_fin")
               .HasColumnType("timestamp");

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
