using Comaagora_API.Entities;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IProdutoPedidoRepository
{
    public Task<ProdutoPedidoEntity> CreateProdutoPedido(CreateProdutoPedidoDTO item, int pedidoId, int estabelecimentoId);
}