using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface IGetCidadesUseCase
{
    public Task<List<GetCidadeDTO>>  Execute(int UfId);
    
}