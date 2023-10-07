using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class GaragemMap : IEntityTypeConfiguration<GaragemModel>
{
    public void Configure(EntityTypeBuilder<GaragemModel> builder)
    {
        builder.HasKey(x => x.IdVaga);
        builder.Property(x => x.PlacaVaga).IsRequired().HasMaxLength(9);
    }
}