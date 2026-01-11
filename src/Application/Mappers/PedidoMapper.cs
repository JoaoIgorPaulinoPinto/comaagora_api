using Comaagora_API.Entities;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Application.Mappers;

public class PedidoMapper
{
    public static GetPedidoDTO PedidoEntity_To_GetPedidoDto(PedidoEntity pedido)
    {
        var dto = new GetPedidoDTO()
        {
            Id = pedido.Id,
            NomeCliente = pedido.NomeCliente,
            TelefoneCliente = pedido.TelefoneCliente,
            Observacao = pedido.Observacao ?? "",
            MetodoPagamento = pedido.MetodoPagamento.Nome,
            Status = pedido.PedidoStatus.Nome,
        };
        return dto;
    }
    public static PedidoEntity CreatePedidoDto_To_PedidoEntity(CreatePedidoDTO dto, int estabelecimentoId)
    {
        var pedido = new PedidoEntity()
        {
            EstabelecimentoId = estabelecimentoId,
            MetodoPagamentoId = dto.MetodoPagamento,
            Observacao = dto.Observacao,
            NomeCliente =  dto.NomeCliente,
            TelefoneCliente = dto.TelefoneCliente,
        };
        return pedido;
    }
}