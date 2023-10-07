using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios;
using concessionaria_WEBAPI.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConcessionariaDBContext>();
/*builder.Services.AddEntityFrameworkSqlServer().
AddDbContext<ConcessionariaDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
);*/
builder.Services.AddScoped<IOficinaRepositorio, OficinaRepositorio>();
builder.Services.AddScoped<IMensalistaRepositorio, MensalistaRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
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
