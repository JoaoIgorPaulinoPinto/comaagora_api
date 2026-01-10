using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreatePedidoUseCase
{
    public Task<bool> CreatePedido(string estabelecimentoSlug, CreatePedidoDTO pedidoDto);
}