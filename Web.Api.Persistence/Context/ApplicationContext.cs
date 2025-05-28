 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;

namespace Web.Api.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ApplicationContext(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbStorageContext");
        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoImagen> ProductoImagen { get; set; }
        public DbSet<Empresa> Empresa { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
