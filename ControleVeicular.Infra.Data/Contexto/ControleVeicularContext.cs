using ControleVeicular.Domain.Entities;
using ControleVeicular.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace ControleVeicular.Infra.Data.Contexto
{
    public class ControleVeicularContext : DbContext
    {
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        private void AdicionarConfiguracoes(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarcaConfiguration());
            modelBuilder.ApplyConfiguration(new ModeloConfiguration());
            modelBuilder.ApplyConfiguration(new AnuncioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Remove OneToManyCascadeDeleteConvention e ManyToManyCascadeDeleteConvention
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                //Mantém nome da Entitidade como foi criada (PluralizingTableNameConvention)
                entityType.SetTableName(entityType.DisplayName());
            }

            AdicionarConfiguracoes(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
