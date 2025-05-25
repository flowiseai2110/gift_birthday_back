using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;

namespace Web.Api.Persistence.Configuraciones
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            // table
            builder.ToTable("empresa", "config");

            // key
            builder.HasKey(t => t.empresa_id);

            // properties
            builder.Property(t => t.empresa_id)
                .HasColumnName("i_empresa_id")
                .HasColumnType("integer");

            builder.Property(t => t.razon_social)
                .HasColumnName("v_razon_social")
                .HasColumnType("varchar");

            builder.Property(t => t.ruc)
                .HasColumnName("v_ruc")
                .HasColumnType("varchar");

            builder.Property(t => t.direccion)
                .HasColumnName("v_direccion")
                .HasColumnType("varchar");

            builder.Property(t => t.telefono_principal)
                .HasColumnName("v_telefono_principal")
                .HasColumnType("varchar");

            builder.Property(t => t.celular_principal)
                .HasColumnName("v_celular_principal")
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
