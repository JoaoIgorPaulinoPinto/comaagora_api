using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.Data.Repositories;

public class EstabelecimentoRepository : IEstabelecimentoRepository
{
    private readonly AppDbContext _context;

    public EstabelecimentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetEstabelecimentoDTO?> GetEstabelecimentoData(string estabelecimentoSlug)
    {
        return await _context.Estabelecimentos
            .AsNoTracking()
            .Where(a => a.Slug == estabelecimentoSlug)
            .Select(e => new GetEstabelecimentoDTO
            {
                Nome = e.NomeFantasia,

                HorarioFuncionamento = e.HorarioFuncionamentos
                    .Select(h => new GetHorarioFuncionamentoDTO
                    {
                        DiaSemana = h.DiaSemana,
                        Abertura = h.Abertura,
                        Fechamento = h.Fechamento
                    })
                    .ToList(),

                Telefone = e.Telefone,
                Whatsapp = e.Whatsapp,
                TaxaEntrega = e.TaxaEntrega,
                PedidoMinimo = e.PedidoMinimo,
                Endereco = _context.Enderecos
                    .Where(end => end.Usuario == e.Id)
                    .Select(end => new GetEnderecoDTO
                    {
                        Rua = end.Rua,
                        Numero = end.Numero,
                        Bairro = end.Bairro,
                        Cidade = end.CidadeEntity.Nome,
                        Uf = end.UfEntity.Nome,
                        Cep = end.Cep
                    })
                    .FirstOrDefault(),
            })
            .FirstOrDefaultAsync();         
    }

    public async Task<int?> GetEstabelecimentoId(string estabelecimentoSlug)
    {
        var estabelecimento = await _context.Estabelecimentos
            .AsNoTracking()
            .Where(a => a.Slug == estabelecimentoSlug)
            .FirstOrDefaultAsync();

        if (estabelecimento != null)
        {
            return estabelecimento.Id;
        }

        throw new Exception("ID invalid");
    }
}