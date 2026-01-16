using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Entities;
using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.Data.Repositories;

public  class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    private IPedidoRepository _pedidoRepositoryImplementation;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int?> CreatePedido(PedidoEntity pedido, string? token)
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

    public async Task<List<GetPedidoDTO>> GetPedidos(int codigoPedido)
    {
        return await _context.Pedidos
            .AsNoTracking()
            .Where(p => p.Id == codigoPedido)
            .Select(p => new GetPedidoDTO()
            {
                Id = p.Id,
                MetodoPagamento = p.MetodoPagamento.Nome,
                NomeCliente = p.NomeCliente,
                Observacao = p.Observacao,

                ProdutoPedidos = p.ProdutoPedidos.Select(pp => new GetProdutoPedidoDTO()
                    {
                        Produto = pp.Produto.Nome,
                        Preco = pp.Produto.Preco,
                        Quantidade = pp.Quantidade
                    }).ToList(),
                Status = p.PedidoStatus.Nome,
                TelefoneCliente =  p.TelefoneCliente
            }).ToListAsync();
    }
}