using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Data.Map;

namespace concessionaria_WEBAPI.Data{
    public class ConcessionariaDBContext:DbContext{
        public ConcessionariaDBContext(DbContextOptions<ConcessionariaDBContext> options) : base(options){} 
        public DbSet<OficinaModel> Oficina {get;set;}
        public DbSet<ClienteModel> Cliente {get;set;}
        public DbSet<PedidoModel> Pedido {get;set;}
        public DbSet<MensalistaModel>? Mensalista {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=estacionamento.db;Cache=Shared");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OficinaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}