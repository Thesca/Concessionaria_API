using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class OficinaMap : IEntityTypeConfiguration<OficinaModel>
{
    public void Configure(EntityTypeBuilder<OficinaModel> builder)
    {
        builder.HasKey(x => x.IdCarroOficina);
        builder.Property(x => x.Procedimento).IsRequired().HasMaxLength(511);
        
    }
}