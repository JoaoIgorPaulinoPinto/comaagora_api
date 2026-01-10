using Comaagora_API.src.Application.DTOs;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;

namespace Comaagora_API.Services.UseCases;

public class GetEstabelecimentoUseCase : IGetEstabelecimentoUseCase
{
    private readonly IEstabelecimentoRepository _repository;

    public GetEstabelecimentoUseCase(IEstabelecimentoRepository repo)
    {
        _repository = repo;
    }
    public Task<GetEstabelecimentoDTO?> GetEstabelecimentoData(string estabelecimentoSlug)
    {
       return _repository.GetEstabelecimentoData(estabelecimentoSlug);
    }
}