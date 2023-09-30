using concessionaria_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace concessionaria_WEBAPI.Data{
    public class ConcessionariaDBContext:DbContext{
        public DbSet<Teste>? Teste {get; set;}     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=estacionamento.db;Cache=Shared");
        }
    }
}