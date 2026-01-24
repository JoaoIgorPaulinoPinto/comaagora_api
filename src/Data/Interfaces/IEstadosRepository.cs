using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IEstadosRepository
{
    public Task<List<GetEstadoDTO>> Get();
}