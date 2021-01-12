using ControleVeicular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVeicular.Infra.Data.EntityConfig
{
    public class AnuncioConfiguration : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(c => c.AnuncioId);
            
            builder.Property(c => c.Ano)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(c => c.Cor)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.TipoCombustivel)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.ValorCompra)
                .HasColumnType("decimal(19,4");

            builder.Property(c => c.ValorVenda)
                .HasColumnType("decimal(19,4");
        }
    }
}
