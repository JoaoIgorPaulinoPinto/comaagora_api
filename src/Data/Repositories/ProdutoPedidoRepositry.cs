using Comaagora_API.Data.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Repositories;

public class ProdutoPedidoRepositry :IProdutoPedidoRepository
{
    public Task<GetProdutoPedidoDTO> CreateProdutoPedido(CreateProdutoPedidoDTO item) => throw new NotImplementedException();
}