using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IEnderecoRepository
{
    public Task<GetEnderecoDTO>  GetEndereco(int id);
    public bool CreateEndereco(CreateEnderecoDTO endereco, int pedidoId);
}