using Comaagora_API.Entities;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IPedidoRepository
{
    public Task<bool> CreatePedido(PedidoEntity pedido);
}