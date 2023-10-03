/*using concessionaria_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace concessionaria_WEBAPI.Data.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<VeiculoModel>
    {
        public void Configure(EntityTypeBuilder<VeiculoModel> builder)
        {
            builder.HasKey(x => x.PlacaVeiculo);
            builder.Property(x => x.AnoVeiculo).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ModeloVeiculo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Valor).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Descricao);
        }
    }
}
*/