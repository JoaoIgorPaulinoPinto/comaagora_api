using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class GetEstadosUseCase :IGetEstadosUseCase
{
    private readonly IEstadosRepository _repository;

    public GetEstadosUseCase(IEstadosRepository repo)
    {
        _repository = repo;
    }
    
    public async Task<List<GetEstadoDTO>> Execute()
    {
        return await _repository.Get();
    }
}
