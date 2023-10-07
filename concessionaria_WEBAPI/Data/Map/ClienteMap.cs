using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
{
    public void Configure(EntityTypeBuilder<ClienteModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Email).HasMaxLength(255);
        builder.Property(x => x.Telefone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Ativo).IsRequired();
        
    }
}