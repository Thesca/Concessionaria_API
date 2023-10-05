using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class ClienteMap : IEntityTypeConfiguration<PedidoModel>
{
    public void Configure(EntityTypeBuilder<PedidoModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Valor).IsRequired();
        builder.Property(x => x.Descricao).HasMaxLength(255);
        builder.Property(x => x.ClienteId);
        builder.HasOne(x => x.Cliente);
    }
}