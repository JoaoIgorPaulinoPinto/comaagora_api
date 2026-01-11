using Comaagora_API.Application.Mappers;
using Comaagora_API.Data;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;

public class CreatePedidoUseCase : ICreatePedidoUseCase
{
    private readonly IDbTransactionHelper _dbTransactionsHelper; // Usar Interface
    private readonly IPedidoRepository _repository;
    private readonly IGetEstabelecimentoIdUseCase _getEstabelecimentoIdUseCase;
    private readonly ICreateEnderecoUseCase _createEnderecoUseCase;
    private readonly ICreateProdutoPedido _createProdutoPedido;

    public CreatePedidoUseCase(
        ICreateProdutoPedido createProdutoPedido, 
        IDbTransactionHelper transactionsHelper, // Interface aqui
        ICreateEnderecoUseCase createEnderecoUseCase, 
        IGetEstabelecimentoIdUseCase getEstabelecimentoIdUseCase, 
        IPedidoRepository repository)
    {
        _createProdutoPedido = createProdutoPedido;
        _dbTransactionsHelper = transactionsHelper;
        _createEnderecoUseCase = createEnderecoUseCase;
        _repository = repository;
        _getEstabelecimentoIdUseCase = getEstabelecimentoIdUseCase;
    }

    public async Task<bool> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto)
    {
        await _dbTransactionsHelper.BeginTransactionAsync();

        try
        {
            // 1. Validar Estabelecimento
            var estabelecimentoId = await _getEstabelecimentoIdUseCase.Execute(estabelecimentoSlug);
            if (estabelecimentoId == null)
            {
                await _dbTransactionsHelper.RollbackTransactionAsync();
                return false;
            }

            // 2. Criar Pedido Base
            var pedido = PedidoMapper.CreatePedidoDto_To_PedidoEntity(pedidoDto, estabelecimentoId.Value);
            var pedidoCadastradoId = await _repository.CreatePedido(pedido);
            
            if (pedidoCadastradoId == null)
            {
                await _dbTransactionsHelper.RollbackTransactionAsync();
                return false;
            }

            // 3. Adicionar Endereço e Itens (IMPORTANTE: Adicionado await)
            CreateEnderecoDTO endereco = pedidoDto.Endereco;
            // Nota: Verifique se aqui não deveria ser o ID do Pedido ou ID do Usuário
            await _createEnderecoUseCase.Execute(endereco, (int)pedidoCadastradoId);
            await _createProdutoPedido.Execute(pedidoDto.ProdutoPedidos, (int)pedidoCadastradoId, (int)estabelecimentoId);

            // 4. Sucesso total
            await _dbTransactionsHelper.CommitTransactionAsync();
            return true; // Retornar true em caso de sucesso
        }
        catch (Exception)
        {
            await _dbTransactionsHelper.RollbackTransactionAsync();
            // Logar o erro aqui (ex: ILogger)
            return false;
        }
    }
}