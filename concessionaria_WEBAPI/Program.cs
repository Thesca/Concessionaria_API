using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace concessionaria_WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ConcessionariaDBContext>();
            //builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ConcessionariaDBContext>(
            //    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            // );

            builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
            //Toda vez que chamar a interface, ele vai instanciar a classe.

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();    
        }
    }
}