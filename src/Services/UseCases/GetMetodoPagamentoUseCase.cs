using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class GetMetodoPagamentoUseCase :IGetMetodoPagamentoUseCase
{
    
    private readonly IMetodoPagamentoRepository _repository;

    public GetMetodoPagamentoUseCase(IMetodoPagamentoRepository repo)
    {
        _repository = repo;
    }
    
    public async Task<List<GetMetodoPagamentoDTO>> Execute(string estabelecimentoSlug)
    {
        return await _repository.GetMetodosPagamento(estabelecimentoSlug);
    }
}