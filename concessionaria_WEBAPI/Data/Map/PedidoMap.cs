using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Data.Map;

public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
{
    public void Configure(EntityTypeBuilder<PedidoModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.Descricao).HasMaxLength(255);
        builder.Property(x => x.ClienteId);
        builder.HasOne(x => x.Cliente);
        builder.Property(x => x.MensalistaId);
        builder.HasOne(x => x.Mensalista);
        builder.Property(x => x.FuncionarioId);
        builder.HasOne(x => x.Funcionario);
        builder.Property(x => x.VeiculoId);
        builder.HasOne(x => x.Veiculo);
    }
}