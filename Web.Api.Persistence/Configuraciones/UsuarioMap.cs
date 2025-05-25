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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // table
            builder.ToTable("usuario", "config");

            // key
            builder.HasKey(t => t.usuarioId);

            // properties
            builder.Property(t => t.usuarioId)
                .HasColumnName("i_usuario_id")
                .HasColumnType("integer");

            builder.Property(t => t.localComercialId)
                .HasColumnName("i_local_comercial_id")
                .HasColumnType("integer");
            
            builder.Property(t => t.numero_documento)
            .HasColumnName("v_numero_documento")
            .HasColumnType("varchar");

            builder.Property(t => t.tipo_documento)
               .HasColumnName("v_tipo_documento")
               .HasColumnType("varchar");

            builder.Property(t => t.nombre)
                .HasColumnName("v_nombre")
                .HasColumnType("varchar");

            builder.Property(t => t.apellido_paterno)
                .HasColumnName("v_apellido_paterno")
                .HasColumnType("varchar");

            builder.Property(t => t.apellido_materno)
                .HasColumnName("v_apellido_materno")
                .HasColumnType("varchar");

            builder.Property(t => t.fecha_nacimiento)
                .HasColumnName("d_fecha_nacimiento")
                .HasColumnType("timestamp");

            builder.Property(t => t.celular)
               .HasColumnName("v_celular")
               .HasColumnType("varchar");

            builder.Property(t => t.correo_electronico)
              .HasColumnName("v_correo_electronico")
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
