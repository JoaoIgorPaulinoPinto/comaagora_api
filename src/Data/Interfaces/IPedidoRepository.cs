using Comaagora_API.Entities;
using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IPedidoRepository
{
    public Task<int?> CreatePedido(PedidoEntity pedido, string token);
    public Task<List<GetPedidoDTO>> GetPedidos(string token);
    public Task<List<GetPedidoDTO>> GetPedidos(int codigoPedido);
}