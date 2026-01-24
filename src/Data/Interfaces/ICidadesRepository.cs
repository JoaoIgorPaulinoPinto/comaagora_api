using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface ICidadesRepository
{
    public Task<List<GetCidadeDTO>> Get(int ufId);
}