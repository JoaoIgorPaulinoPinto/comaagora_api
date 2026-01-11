using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreatePedidoUseCase
{
    public Task<bool> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto);
}