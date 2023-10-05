using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Data.Map;

namespace concessionaria_WEBAPI.Data{
    public class ConcessionariaDBContext:DbContext{
        public ConcessionariaDBContext(DbContextOptions<ConcessionariaDBContext> options) : base(options){}
        public DbSet<Teste>? Teste {get; set;}    
        public DbSet<OficinaModel>? Oficina {get;set;}
        public DbSet<MensalistaModel>? Mensalista {get;set;}
        public DbSet<GaragemModel>? Garagem {get;set;}
        public DbSet<DocumentoModel>? Documento {get;set;}
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