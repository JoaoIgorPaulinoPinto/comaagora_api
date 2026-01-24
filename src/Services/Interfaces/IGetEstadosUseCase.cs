using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface IGetEstadosUseCase
{
    public Task<List<GetEstadoDTO>>  Execute();
}