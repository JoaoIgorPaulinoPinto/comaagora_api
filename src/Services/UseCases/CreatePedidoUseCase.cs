using System.Diagnostics.CodeAnalysis;
using Comaagora_API.Application.Mappers;
using Comaagora_API.Data;
using Comaagora_API.Data.Database;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.UseCases;

public class CreatePedidoUseCase : ICreatePedidoUseCase
{
    private readonly DbTransactionsHelper _dbTransactionsHelper;
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IGetEstabelecimentoId _getEstabelecimentoId;
    private readonly ICreateEnderecoUseCase _createEnderecoUseCase;
  
    private ICreatePedidoUseCase _createPedidoUseCase;

    public CreatePedidoUseCase(DbTransactionsHelper transactionsHelper,ICreateEnderecoUseCase  createEnderecoUseCase, IGetEstabelecimentoId getEstabelecimentoId, IPedidoRepository pedidoRepository)
    {
        _dbTransactionsHelper = transactionsHelper;
        _createEnderecoUseCase = createEnderecoUseCase;
        _pedidoRepository = pedidoRepository;
        _getEstabelecimentoId = getEstabelecimentoId;
    }

    public async Task<bool> CreatePedido(string estabelecimentoSlug, CreatePedidoDTO pedidoDto)
    {
        
        //inicia a transação
        await _dbTransactionsHelper.BeginTransactionAsync();
        //pega o id do estabelecimento
        var estabelecimentoId = await _getEstabelecimentoId.GetEstabelecimentoId(estabelecimentoSlug);
        if (estabelecimentoId == null)
            if (estabelecimentoId == null)
            {
                await _dbTransactionsHelper.RollbackTransactionAsync();
                return false;
            }
        
        //cria o pedido base
        var pedido = PedidoMapper.CreatePedidoDto_To_PedidoEntity(pedidoDto, estabelecimentoId.Value);
        var pedidoCadastradoId = await _pedidoRepository.CreatePedido(pedido);
        if (pedidoCadastradoId == null)
        {
            await _dbTransactionsHelper.RollbackTransactionAsync();
            return false;
        }
        else
        {
            //adiciona o endereco ao pedido
            CreateEnderecoDTO endereco = pedidoDto.Endereco;
            _createEnderecoUseCase.Execute(endereco, (int)pedidoCadastradoId);
            
        }
    };
}