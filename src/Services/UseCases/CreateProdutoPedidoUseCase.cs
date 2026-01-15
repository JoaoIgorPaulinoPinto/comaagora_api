using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Comaagora_API.Services.UseCases;

public class CreateProdutoPedidoUseCase : ICreateProdutoPedidoUseCase
{
    private readonly IProdutoPedidoRepository _repository;

    public CreateProdutoPedidoUseCase(IProdutoPedidoRepository repository)
    {
        _repository = repository;
    }
    public Task Execute(List<CreateProdutoPedidoDTO> produtoPedidoDto, int pedidoId, int estabelecimentoId)
    {
        if (produtoPedidoDto == null || produtoPedidoDto.Count == 0 || pedidoId == null || estabelecimentoId == null)
        {
            return Task.FromException(new Exception("401 BadRequest"));
        }
        try
        {
            return _repository.CreateProdutoPedido(produtoPedidoDto, pedidoId, estabelecimentoId);
        }
        catch
        {
            throw new Exception("Não foi possivel criar item do pedido");
        }
    }
}