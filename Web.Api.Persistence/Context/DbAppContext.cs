 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Web.Api.Domain.Entities; 
using Web.Api.Domain.Entities.config;
using Web.Data.Core;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml;

namespace Web.Api.Persistence.Context
{
    public class DbAppContext : DbContext, IDbContext
    {
        private readonly string _connstr;
         
        public DbAppContext(string connstr ) {
            this._connstr = connstr;
        }
        public DbAppContext(DbContextOptions<DbAppContext> options)
           : base(options)
        {

        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoImagen> ProductoImagen { get; set; }
        //public DbSet<Empresa> Empresa { get; set; }

        public async Task EnsureAutoHistoryExtension()
        {
            ChangeTracker.DetectChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(_connstr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EmpresaMap());
            //modelBuilder.ApplyConfiguration(new LocalComercialMap());
            //modelBuilder.ApplyConfiguration(new ProductoMap());
            //modelBuilder.ApplyConfiguration(new ProductoImagenMap());
        }
         
    }
}
