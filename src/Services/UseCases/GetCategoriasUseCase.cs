using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Data.Interfaces;
using Comaagora_API.src.Services.Interfaces;

namespace Comaagora_API.src.Services.UseCases;

public class GetCategoriasUseCase : IGetCategoriasUseCase
{
    
    private readonly IProdutoCategoriaRepository _repository;

    public GetCategoriasUseCase(IProdutoCategoriaRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCategoriaProdutoDTO>> Execute(string estabelecimentoSlug)
    {
       return (await _repository.GetCategoriasAsync(estabelecimentoSlug));
    }
}