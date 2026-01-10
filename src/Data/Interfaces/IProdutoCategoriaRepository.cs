using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.src.Data.Interfaces;

public interface IProdutoCategoriaRepository
{
    public Task<List<GetCategoriaProdutoDTO>> GetCategoriasAsync(string estabelecimentoSlug);
}