using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.src.Data.Interfaces
{
    public interface IProdutosRepository
    {
        public  Task<List<GetProdutoDTO>> GetProdutosAsync(string estabelecimentoSlug);

    }
}
