using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class CreateEnderecoUseCase : ICreateEnderecoUseCase
{
    public Task<GetEnderecoDTO?> Execute(CreateEnderecoDTO endereco, int pedidoId)
    {
        throw new NotImplementedException();
    }


}