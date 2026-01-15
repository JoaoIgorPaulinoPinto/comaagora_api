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
    public Task<bool> Execute(CreateEnderecoDTO endereco, int pedidoId)
    {
        try
        {
            _repository.CreateEndereco(endereco, pedidoId);
            return Task.FromResult(true);
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao salvar ");
        }
    }
}