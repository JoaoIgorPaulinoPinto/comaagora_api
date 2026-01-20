using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.Data.Repositories;

public class MetodoPagamentoRepository:IMetodoPagamentoRepository
{
    private readonly AppDbContext _context;

    public MetodoPagamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetMetodoPagamentoDTO>> GetMetodosPagamento(string estabelecimentoSlug)
    {
       return await
           _context.MetodosPagamento.
           Select(m => new GetMetodoPagamentoDTO
           { 
               Id = m.Id,
               Nome = m.Nome
           }).ToListAsync();
    }
}