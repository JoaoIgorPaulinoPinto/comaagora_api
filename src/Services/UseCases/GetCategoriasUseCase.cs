using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Data.Interfaces;
using Comaagora_API.src.Services.Interfaces;

namespace Comaagora_API.src.Services.UseCases;

public class GetCategoriasUseCase : IGetCategoriasUseCase
{
    
    private readonly IProdutoCategoriaRepository _repo;

    public GetCategoriasUseCase(IProdutoCategoriaRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<List<GetCategoriaProdutoDTO>> GetCategoriasAsync(string estabelecimentoSlug)
    {
       return (await _repo.GetCategoriasAsync(estabelecimentoSlug));
    }
}