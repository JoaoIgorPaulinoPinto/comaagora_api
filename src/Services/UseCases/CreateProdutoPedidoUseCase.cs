using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Comaagora_API.Services.UseCases;

public class CreateProdutoPedidoUseCase : ICreateProdutoPedido
{
    private readonly IProdutoPedidoRepository _repository;

    public CreateProdutoPedidoUseCase(IProdutoPedidoRepository repository)
    {
        _repository = repository;
    }
    public Task Execute(List<CreateProdutoPedidoDTO> produtoPedidoDto, int pedidoId, int estabelecimentoId)
    {
        return _repository.CreateProdutoPedido(produtoPedidoDto, pedidoId, estabelecimentoId);
    }
}