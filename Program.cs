using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Data.Repositories;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.Services.UseCases;
using Comaagora_API.src.Data.Interfaces;
using Comaagora_API.src.Data.Repositories;
using Comaagora_API.src.Services.Interfaces;
using Comaagora_API.src.Services.UseCases;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Controllers
builder.Services.AddControllers();
// UseCases
builder.Services.AddScoped<IGetProdutosUseCase, GetProdutosUseCase>();
builder.Services.AddScoped<IGetEstabelecimentoUseCase, GetEstabelecimentoUseCase>();
builder.Services.AddScoped<IGetCategoriasUseCase, GetCategoriasUseCase>();

// Repositories
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();
builder.Services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
builder.Services.AddScoped<IProdutoCategoriaRepository, ProdutoCategoriaRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conn = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(conn, ServerVersion.AutoDetect(conn));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
