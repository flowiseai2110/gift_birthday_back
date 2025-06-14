using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;

namespace Web.Api.Persistence.Configuraciones
{
    public class EventoMap : IEntityTypeConfiguration<EventoBE>
    {
        public void Configure(EntityTypeBuilder<EventoBE> builder)
        {
            // Tabla y esquema
            builder.ToTable("evento", "public");

            // Clave primaria
            builder.HasKey(t => t.id);

            // Columnas
            builder.Property(t => t.id)
                   .HasColumnName("id");

            builder.Property(t => t.nombre)
                   .HasColumnName("nombre")
                   .HasColumnType("varchar");

            builder.Property(t => t.descripcion)
                   .HasColumnName("descripcion")
                   .HasColumnType("varchar");
             
            builder.Property(t => t.fecha_inicio)
                   .HasColumnName("fecha_inicio")
                   .HasColumnType("timestamp");

            builder.Property(t => t.fecha_fin)
                   .HasColumnName("fecha_fin")
                   .HasColumnType("timestamp");

            builder.Property(t => t.hora_inicio)
                   .HasColumnName("hora_inicio")
                   .HasColumnType("time without time zone");

            builder.Property(t => t.hora_fin)
                   .HasColumnName("hora_fin")
                   .HasColumnType("time without time zone");
             
            builder.Property(t => t.activo)
                   .HasColumnName("activo");

            builder.Property(t => t.usuario_registro)
                   .HasColumnName("usuario_registro")
                   .HasColumnType("varchar");

            builder.Property(t => t.fecha_registro)
                   .HasColumnName("fecha_registro")
                   .HasColumnType("timestamp");

            builder.Property(t => t.usuario_modificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasColumnType("varchar");

            builder.Property(t => t.fecha_modificacion)
                   .HasColumnName("fecha_modificacion")
                   .HasColumnType("timestamp");
             
        }


    }
}
