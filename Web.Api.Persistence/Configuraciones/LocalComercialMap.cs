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
    public class LocalComercialMap : IEntityTypeConfiguration<LocalComercial>
    {
        public void Configure(EntityTypeBuilder<LocalComercial> builder)
        {
            // table
            builder.ToTable("local_comercial", "config");

            // key
            builder.HasKey(t => t.local_comercial_id);

            // properties
            builder.Property(t => t.local_comercial_id)
                .HasColumnName("i_local_comercial_id")
                .HasColumnType("integer");

            builder.Property(t => t.empresa_id)
               .HasColumnName("i_empresa_id")
               .HasColumnType("integer");

            builder.Property(t => t.nombre_comercial)
                .HasColumnName("v_nombre_comercial")
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
            
            builder.Property(t => t.tipo_horario)
               .HasColumnName("v_tipo_horario")

               .HasColumnType("varchar");
            builder.Property(t => t.hora_inicio)
              .HasColumnName("t_hora_inicio")
              .HasColumnType("time");

            builder.Property(t => t.hora_fin)
               .HasColumnName("t_hora_fin")
               .HasColumnType("time");
             
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

            // relationships
            //builder.HasOne(t => t.Empresa)
            //    .WithMany(t => t.localesComerciales)
            //    .HasForeignKey(d => d.empresa_id)
            //    .HasConstraintName("FK_EMPRESA");

           
        }
    }
}
