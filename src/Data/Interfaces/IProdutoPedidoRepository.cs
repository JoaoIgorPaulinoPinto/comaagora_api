using Comaagora_API.Entities;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IProdutoPedidoRepository
{
    public Task CreateProdutoPedido(List<CreateProdutoPedidoDTO> items, int pedidoId, int estabelecimentoId);
}