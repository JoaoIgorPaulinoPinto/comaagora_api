using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class CreateEnderecoUseCase : ICreateEnderecoUseCase
{
    private readonly IEnderecoRepository _repository;

    public CreateEnderecoUseCase(IEnderecoRepository repository)
    {
        _repository= repository;
    }
    public Task<GetEnderecoDTO?> Execute(CreateEnderecoDTO endereco, int pedidoId)
    {
        _repository.CreateEndereco(endereco);
        return Task.FromResult<GetEnderecoDTO?>(null);
    }
}