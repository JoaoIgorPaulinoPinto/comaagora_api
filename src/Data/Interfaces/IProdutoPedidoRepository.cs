using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IProdutoPedidoRepository
{
    public Task<GetProdutoPedidoDTO> CreateProdutoPedido(CreateProdutoPedidoDTO item);
}