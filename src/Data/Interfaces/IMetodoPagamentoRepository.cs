using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IMetodoPagamentoRepository
{
    public Task<List<GetMetodoPagamentoDTO>> GetMetodosPagamento(string estabelecimentoDTO);
}