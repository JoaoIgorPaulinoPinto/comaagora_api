using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Entities;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Comaagora_API.Data.Repositories;

public  class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePedido(PedidoEntity pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        _context.SaveChanges();
        return true;
    }
}