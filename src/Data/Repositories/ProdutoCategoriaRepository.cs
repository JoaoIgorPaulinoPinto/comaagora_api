using Comaagora_API.Data.Database;
using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.src.Data.Repositories;

public class ProdutoCategoriaRepository : IProdutoCategoriaRepository
{
    private readonly AppDbContext _dbContext;

    public ProdutoCategoriaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Application.DTOs.GetCategoriaProdutoDTO>> GetCategoriasAsync(string estabelecimentoSlug)
    {
        return await _dbContext.ProdutoCategorias.AsNoTracking()
            .Where(p => p.Estabelecimento.Slug == estabelecimentoSlug)
            .Select(p => new GetCategoriaProdutoDTO(
                p.Id,
                p.Nome)
            ).ToListAsync();
    }
}