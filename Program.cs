using comaagora.Data;
using comaagora.Repositories;
using comaagora.Services.Categoria;
using comaagora.Services.Endereco;
using comaagora.Services.Estabelecimento;
using comaagora.Services.Localizacao;
using comaagora.Services.MetodoPagamento;
using comaagora.Services.Pedido;
using comaagora.Services.Produto;
using comaagora.Services.ProdutoPedido;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURAÇÃO DE PORTA PARA O RENDER ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- BANCO DE PADADOS ---
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(conn, ServerVersion.AutoDetect(conn));
});

// --- DEPENDÊNCIAS (SERVICES) ---
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IProdutoPedidoService, ProdutoPedidoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
builder.Services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ILocalizacaoService, LocalizacaoService>();

// --- DEPENDÊNCIAS (REPOSITORIES) ---
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<MetodoPagamentoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<EstabelecimentoRepository>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<LocalizacaoRepository>();

var app = builder.Build();

// --- PIPELINE DE REQUISIÇÕES (MIDDLEWARES) ---

// Swagger habilitado para todos os ambientes no Render para facilitar testes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComaAgora API v1");
    // Se quiser que o Swagger seja a página inicial, deixe a RoutePrefix vazia:
    // c.RoutePrefix = string.Empty; 
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// IMPORTANTE: UseHttpsRedirection é desativado no Render pois o Proxy deles já cuida disso.
// app.UseHttpsRedirection(); 

app.MapControllers();

// Rota raiz para confirmar que a API está de pé
app.MapGet("/", () => "ComaAgora API está online e rodando!");

app.Run();
