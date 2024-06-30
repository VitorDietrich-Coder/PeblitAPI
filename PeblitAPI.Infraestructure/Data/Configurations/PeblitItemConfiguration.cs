using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeblitAPI.Domain.Entities;

namespace PeblitAPI.Infrastructure.Data.Configurations;

public class PeblitItemConfiguration : IEntityTypeConfiguration<PeblitItem>
{
    public void Configure(EntityTypeBuilder<PeblitItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(t => t.Id)
          .IsRequired();
        
        builder.Property(t => t.NomePlanta)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Temperatura)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Umidade)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.UmidadeSolo)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Luminosidade)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Pontos)
            .IsRequired();

        builder.Property(t => t.IdFundoAtual)
            .IsRequired();

        builder.Property(t => t.IdRoupaAtual)
            .IsRequired();
    }
}
