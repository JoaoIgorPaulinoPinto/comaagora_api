using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class GetPedidosUseCase : IGetPedidosUseCase
{
    private readonly IPedidoRepository _getPedidoUseCase;

    public GetPedidosUseCase (IPedidoRepository pedidoRepository)
    {
        _getPedidoUseCase =  pedidoRepository;
    }

    public async Task<List<GetPedidoDTO>> Execute(string token)
    {
        return await _getPedidoUseCase.GetPedidos(token);
    }

    public async Task<List<GetPedidoDTO>> Execute(int codigoPedido)
    {
        return await _getPedidoUseCase.GetPedidos(codigoPedido);
    }
}