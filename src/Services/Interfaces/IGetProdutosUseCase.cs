using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.src.Services.Interfaces
{
    public interface IGetProdutosUseCase
    {
        public Task<List<GetProdutoDTO>> GetProdutosAsync(string estabelecimentoSlug);
    }
}
