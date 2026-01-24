using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.Data.Repositories;

public class CidadesRepository : ICidadesRepository
{
    private readonly AppDbContext _context;

    public CidadesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCidadeDTO>> Get(int ufId)
    {
        var uf = await _context.Estados
            .AsNoTracking()
            .Where(e => e.Id == ufId)
            .Select(e => e.Uf)
            .FirstOrDefaultAsync();

        if (uf is null)
            throw new Exception("UF não encontrada");

        return await _context.Cidades
            .AsNoTracking()
            .Where(c => c.Uf == uf)
            .Select(c => new GetCidadeDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Uf = c.Uf
            })
            .ToListAsync();
    }
}