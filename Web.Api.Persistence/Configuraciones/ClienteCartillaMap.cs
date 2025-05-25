using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.proceso;

namespace Web.Api.Persistence.Configuraciones
{
    public class ClienteCartillaMap : IEntityTypeConfiguration<ClienteCartilla>
    {
        public void Configure(EntityTypeBuilder<ClienteCartilla> builder)
        {
            // table
            builder.ToTable("cliente_cartilla", "proceso");

            // key
            builder.HasKey(t => t.cliente_cartilla_id);

            // properties
            builder.Property(t => t.cliente_cartilla_id)
                .HasColumnName("i_cliente_cartilla_id")
                .HasColumnType("integer");

            builder.Property(t => t.cliente_id)
                .HasColumnName("i_cliente_id")
                .HasColumnType("integer");

            builder.Property(t => t.cartilla_promocion_id)
               .HasColumnName("i_cartilla_promocion_id")
               .HasColumnType("integer");

            builder.Property(t => t.local_comercial_id)
             .HasColumnName("i_local_comercial_id")
             .HasColumnType("integer");

            builder.Property(t => t.numero_promocion)
             .HasColumnName("i_numero_promocion")
             .HasColumnType("integer");

            builder.Property(t => t.numero_sello)
             .HasColumnName("i_numero_sello")
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
