using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class DocumentoMap : IEntityTypeConfiguration<DocumentoModel>
{
    public void Configure(EntityTypeBuilder<DocumentoModel> builder)
    {
        builder.HasKey(x => x.PlacaDoc);
        builder.Property(x => x.CRLV).IsRequired();
        builder.Property(x => x.IPVA).IsRequired();
    }
}