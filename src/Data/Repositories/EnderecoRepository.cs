using Comaagora_API.Application.Mappers;
using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Comaagora_API.Data.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly AppDbContext _context;

    public EnderecoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetEnderecoDTO?> GetEndereco(int id)
    {
        var endereco = await _context.Enderecos
            .Where(end => end.Usuario == id)
            .Select(end => new GetEnderecoDTO
            {
                Rua = end.Rua,
                Numero = end.Numero,
                Bairro = end.Bairro,
                Cidade = end.CidadeEntity.Nome,
                Uf = end.UfEntity.Nome,
                Cep = end.Cep
            })
            .FirstOrDefaultAsync();

        return endereco; // já pode ser null
    }

    public bool CreateEndereco(CreateEnderecoDTO endereco)
    {
        var entityEnedereco = EnderecoMapper.CreateEnderecoDto_To_EnderecoEntity(endereco);
        _context.Enderecos.Add(entityEnedereco);
        _context.SaveChanges();
        return true;
    }
}