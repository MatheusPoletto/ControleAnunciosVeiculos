using ControleVeicular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeicular.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.UsuarioId);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => c.Login).IsUnique(true);
        }
    }
}
