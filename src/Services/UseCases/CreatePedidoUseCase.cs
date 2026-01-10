using System.Diagnostics.CodeAnalysis;
using Comaagora_API.Application.Mappers;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Entities;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class CreatePedidoUseCase : ICreatePedidoUseCase
{

    private readonly IPedidoRepository _pedidoRepository;
    private readonly IEstabelecimentoRepository _estabelecimentoRepository;
    private ICreatePedidoUseCase _createPedidoUseCaseImplementation;

    public CreatePedidoUseCase(IPedidoRepository pedidoRepository,
        IEstabelecimentoRepository  estabelecimentoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _estabelecimentoRepository = estabelecimentoRepository;
    }

    public async Task<bool> CreatePedido(string estabelecimentoSlug, CreatePedidoDTO pedidoDto)
    {
        var estabelecimentoId = await _estabelecimentoRepository
            .GetEstabelecimentoId(estabelecimentoSlug);

        if (estabelecimentoId == null) return false;

        var pedido = PedidoMapper.CreatePedidoDtoToEntity(pedidoDto, estabelecimentoId.Value);
        var pedidoProdutos = "a";
        return await _pedidoRepository.CreatePedido(pedido);
        var endereco = "a"; // criar endereco e atribuir ao usuario o Id do pedido
    }
}