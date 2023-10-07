using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class MensalistaMap : IEntityTypeConfiguration<MensalistaModel>
{
    public void Configure(EntityTypeBuilder<MensalistaModel> builder)
    {
        builder.HasKey(x => x.CpfMensalista);
        builder.Property(x => x.DiaDaLocacao).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(255);
    }
}