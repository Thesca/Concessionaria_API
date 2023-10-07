using concessionaria_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace concessionaria_WEBAPI.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.HasKey(x => x.IdFuncionario);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cargo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Salario).HasMaxLength(25);
            builder.Property(x => x.AnoContratatado).HasMaxLength(10);
        }
    }
}
