using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Data.Interfaces;
using Comaagora_API.src.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Comaagora_API.src.Services.UseCases
{
    internal sealed class GetProdutosUseCase : IGetProdutosUseCase
    {

        private readonly IProdutosRepository _produtosRepository;
        public GetProdutosUseCase (IProdutosRepository produtosRepository) { 
        _produtosRepository  = produtosRepository;    
        }

        public async Task<List<GetProdutoDTO>> GetProdutosAsync(string estabelecimentoSlug)
        {
            return await _produtosRepository.GetProdutosAsync(estabelecimentoSlug);
        }
    }
}
