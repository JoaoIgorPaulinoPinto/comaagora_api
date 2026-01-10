using Comaagora_API.Data.Database;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
                                                                                                                                  
namespace Comaagora_API.src.Data.Repositories
{
    internal sealed class ProdutosRepository : IProdutosRepository
    {

        private readonly AppDbContext _dbContext;
        public ProdutosRepository (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetProdutoDTO>> GetProdutosAsync(string estabelecimentoSlug)
        {
            return await _dbContext.Produtos.AsNoTracking()
                .Where(p => p.Estabelecimento.Slug == estabelecimentoSlug)
                .Select(p => new GetProdutoDTO(p.Id, p.Nome,p.Preco, p.ImgUrl, "")).ToListAsync();
        }
    }
}
