using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreateEnderecoUseCase
{
      public Task<GetEnderecoDTO?> Execute(CreateEnderecoDTO endereco, int pedidoId);
}