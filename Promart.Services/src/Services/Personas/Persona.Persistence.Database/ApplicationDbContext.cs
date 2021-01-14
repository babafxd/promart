using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using ModelPersona = Persona.Domain;
using Persona.Persistence.Database.Configuration;



namespace Persona.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }

        public DbSet<ModelPersona.Persona> Personas { get; set; }
        public DbSet<ModelPersona.PersonaDetalle> PersonasDetalles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder
        //    //    .UseMySql("server=127.0.0.1;port=3306;user=root;password=mysql;database=DBPromart")
        //    //    .EnableDetailedErrors()
        //    //    .EnableSensitiveDataLogging();

        //}

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);

        }

        private void ModelConfig(ModelBuilder modelBuilder) 
        {
            new PersonaConfiguration(modelBuilder.Entity<ModelPersona.Persona>());
            new PersonaDetalleConfiguration(modelBuilder.Entity<ModelPersona.PersonaDetalle>());
        }

    }
}
