using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class GetCidadesUseCase : IGetCidadesUseCase
{
    
    private readonly ICidadesRepository _cidadesRepository;

    public GetCidadesUseCase(ICidadesRepository cidadesRepository)
    {
        _cidadesRepository = cidadesRepository;
    }
    public async Task<List<GetCidadeDTO>> Execute(int UfId)
    {
        return await _cidadesRepository.Get(UfId);
    }
}