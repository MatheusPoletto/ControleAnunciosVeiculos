using ControleVeicular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeicular.Infra.Data.EntityConfig
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(c => c.ModeloId);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
