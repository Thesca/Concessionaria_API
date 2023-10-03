using concessionaria_WEBAPI.Data.Map;
using concessionaria_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace concessionaria_WEBAPI.Data
{
    public class ConcessionariaDBContext : DbContext
    {
        public ConcessionariaDBContext(DbContextOptions<ConcessionariaDBContext> options) : base(options)
        {
        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }  //representa a tabela de funcionarios no banco de dados
        //public DbSet<Veiculo> Veiculos { get; set;}     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=estacionamento.db;Cache=Shared");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}