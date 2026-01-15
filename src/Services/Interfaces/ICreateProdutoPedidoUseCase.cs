using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreateProdutoPedidoUseCase
{
    public Task Execute(List<CreateProdutoPedidoDTO> produto, int pedidoId, int estabelecimentoId);
}