using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface IGetMetodoPagamentoUseCase
{
    public Task<List<GetMetodoPagamentoDTO>> Execute(string estabelecimentoSlug);
}