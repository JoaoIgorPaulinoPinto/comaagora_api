using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreateProdutoPedido
{
    public Task Execute(List<CreateProdutoPedidoDTO> endereco, int pedidoId, int estabelecimentoId);
}