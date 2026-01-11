using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Data.Interfaces;
using Comaagora_API.src.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Comaagora_API.src.Services.UseCases
{
    internal sealed class GetProdutosUseCase : IGetProdutosUseCase
    {

        private readonly IProdutosRepository _repository;
        public GetProdutosUseCase (IProdutosRepository repository) { 
        _repository  = repository;    
        }

        public async Task<List<GetProdutoDTO>> Execute(string estabelecimentoSlug)
        {
            return await _repository.GetProdutosAsync(estabelecimentoSlug);
        }
    }
}
