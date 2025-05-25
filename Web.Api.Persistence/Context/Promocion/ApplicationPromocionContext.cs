 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Persistence.Configuraciones;

namespace Web.Api.Persistence.Context.Promocion
{
    public class PromocionContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public PromocionContext(IConfiguration configuration) {
               AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbPromocionContext");
        }
        public DbSet<Cartilla> Cartilla { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<LocalComercial> LocalComercial { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CPromocion> CPromocion { get; set; }
        public DbSet<ClienteCartilla> ClienteCartilla { get; set; }
        public DbSet<ClienteCartillaDetalle> ClienteCartillaDetalle { get; set; }
        public DbSet<CartillaPromocion> CartillaPromocion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(_connectionString); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new EmpresaMap());

            modelBuilder.ApplyConfiguration(new LocalComercialMap());

            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.ApplyConfiguration(new ClienteMap());

            modelBuilder.ApplyConfiguration(new PromocionMap());

            modelBuilder.ApplyConfiguration(new ClienteCartillaMap());

            modelBuilder.ApplyConfiguration(new CartillaMap());

            modelBuilder.ApplyConfiguration(new CartillaPromocionMap());

            modelBuilder.ApplyConfiguration(new ClienteCartillaDetalleMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}
