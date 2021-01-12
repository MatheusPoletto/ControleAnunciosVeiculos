using ControleVeicular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeicular.Infra.Data.EntityConfig
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(c => c.MarcaId);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
