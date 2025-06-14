 using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Persistence.Configuraciones;

namespace Web.Api.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ApplicationContext(IConfiguration configuration) {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbStorageContext");
        }
        public DbSet<EventoBE> Eventos { get; set; } 
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.UseNpgsql(_connectionString).LogTo(Console.WriteLine, LogLevel.Information)
           .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventoBE>().ToTable("evento", "public");
            modelBuilder.ApplyConfiguration(new EventoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
