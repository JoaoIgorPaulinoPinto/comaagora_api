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

    public async Task<int?> CreatePedido(PedidoEntity pedido, string token)
    {
        try
        {
            pedido.SessionToken = token;
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido.Id;
        }
        catch (Exception e)
        {
            throw new Exception(message: "Erro ao salvar!");
        }

    }

    public async Task<List<GetPedidoDTO>> GetPedidos(string token)
    {
        return await (
            from p in _context.Pedidos.AsNoTracking()
            join e in _context.Enderecos.AsNoTracking()
                on p.Id equals e.Usuario into enderecos
            from endereco in enderecos.DefaultIfEmpty()
            where p.SessionToken == token
            select new GetPedidoDTO
            {
                Id = p.Id,
                MetodoPagamento = p.MetodoPagamento.Nome,
                NomeCliente = p.NomeCliente,
                Observacao = p.Observacao,
                Status = p.PedidoStatus.Nome,
                TelefoneCliente = p.TelefoneCliente,

                ProdutoPedidos = p.ProdutoPedidos
                    .Select(pp => new GetProdutoPedidoDTO
                    {
                        Produto = pp.Produto.Nome,
                        Preco = pp.Produto.Preco,
                        Quantidade = pp.Quantidade
                    })
                    .ToList(),

                Endereco = endereco == null
                    ? null
                    : new GetEnderecoDTO
                    {
                        Uf = endereco.UfEntity.Nome,
                        Cidade = endereco.CidadeEntity.Nome,
                        Bairro = endereco.Bairro,
                        Cep = endereco.Cep,
                        Complemento = endereco.Complemento,
                        Numero = endereco.Numero,
                        Rua = endereco.Rua,
                    },

                TaxaEntrega = p.Estabelecimento.TaxaEntrega,

                ValorTotal =
                    p.ProdutoPedidos.Sum(pp =>
                        (pp.Produto.Preco) * pp.Quantidade
                    )
            }
        ).ToListAsync();
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
                TelefoneCliente = p.TelefoneCliente
            }).ToListAsync();
    }
}