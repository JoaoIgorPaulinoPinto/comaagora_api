using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.Data.Repositories;

public class EstadosRepository : IEstadosRepository
{
    private readonly AppDbContext _context;

    public EstadosRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetEstadoDTO>> Get()
    {
        return await _context.Estados
            .AsNoTracking()
            .Select(e => new GetEstadoDTO
            {
                Id = e.Id,
                Uf = e.Uf
            })
            .ToListAsync();
    }
}