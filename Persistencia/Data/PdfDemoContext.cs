using System.Reflection;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
    public class PdfDemoContext : DbContext
    {
        public DbSet<Producto> Productos {get; set;}
        public DbSet<Marca> Marcas {get; set;}


        public PdfDemoContext(DbContextOptions<PdfDemoContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
