using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface IGetPedidosUseCase
{
    public Task<List<GetPedidoDTO>> Execute(string token);
    public Task<List<GetPedidoDTO>> Execute(int codigoPedido);
}