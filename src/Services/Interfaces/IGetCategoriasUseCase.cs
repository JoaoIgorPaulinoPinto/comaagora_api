using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.src.Services.Interfaces;

public interface IGetCategoriasUseCase
{
    public Task<List<GetCategoriaProdutoDTO>> GetCategoriasAsync(string estabelecimentoSlug);
}