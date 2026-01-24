using System.Data.Common;
using Comaagora_API.Entities;
using Comaagora_API.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Comaagora_API.Data.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ProdutoEntity> Produtos { get; set; } = null!;
    public DbSet<ProdutoPedidoEntity> ProdutosPedido { get; set; } = null!;
    public DbSet<ProdutoCategoriaEntity> ProdutoCategorias { get; set; } = null!;
    public DbSet<EstabelecimentosEntity> Estabelecimentos { get; set; } = null!;
    public DbSet<EnderecoEntity> Enderecos { get; set; } = null!;
    public DbSet<EstadoEnity> Estados { get; set; } = null!;
    public DbSet<MunicipioEntity> Cidades { get; set; } = null!;
    public DbSet<StatusEntity> Status { get; set; } = null!;
    public DbSet<PedidoEntity> Pedidos { get; set; } = null!;
    public DbSet<MetodoPagamentoEntity> MetodosPagamento { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


}