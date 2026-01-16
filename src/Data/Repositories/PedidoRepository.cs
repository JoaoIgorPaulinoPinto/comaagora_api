using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Entities;
using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Comaagora_API.Data.Repositories;

public  class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    private IPedidoRepository _pedidoRepositoryImplementation;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int?> CreatePedido(PedidoEntity pedido)
    {
        try
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido.Id;
        }
        catch (Exception e)
        {
            throw new Exception(message: "Erro ao salvar!");
            return null;
        }

    }

    public Task<List<GetPedidoDTO>> GetPedidos(string token)
    {
        return _pedidoRepositoryImplementation.GetPedidos(token);
    }

    public Task<List<GetPedidoDTO>> GetPedidos(int codigoPedido)
    {
        return _pedidoRepositoryImplementation.GetPedidos(codigoPedido);
    }
}