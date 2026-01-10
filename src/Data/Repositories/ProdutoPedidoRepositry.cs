using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Entities;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Repositories;

public class ProdutoPedidoRepositry :IProdutoPedidoRepository
{
    private readonly AppDbContext _context;

    public ProdutoPedidoRepositry(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ProdutoPedidoEntity> CreateProdutoPedido(
        CreateProdutoPedidoDTO item, 
        int pedidoId,
        int estabelecimentoId)
    {
        var entidade = new ProdutoPedidoEntity()
        {
            EstabelecimentoId = estabelecimentoId,
            PedidoId = pedidoId,
            ProdutoId = item.ProdutoId,
            Quantidade = item.Quantidade,
        };
         _context.ProdutosPedido.Add(entidade);
         _context.SaveChanges();
         return entidade;
    }
}