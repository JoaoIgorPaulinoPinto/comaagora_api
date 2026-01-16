using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Comaagora_API.Application.Mappers;
using Comaagora_API.Data;
using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;
using Microsoft.IdentityModel.Tokens;

public class CreatePedidoUseCase : ICreatePedidoUseCase
{
    private readonly IDbTransactionHelper _dbTransactionsHelper; // Usar Interface
    private readonly IPedidoRepository _repository;
    private readonly IGetEstabelecimentoIdUseCase _getEstabelecimentoIdUseCase;
    private readonly ICreateEnderecoUseCase _createEnderecoUseCase;
    private readonly ICreateProdutoPedidoUseCase _createProdutoPedidoUseCase;

    public CreatePedidoUseCase(
        ICreateProdutoPedidoUseCase createProdutoPedidoUseCase, 
        IDbTransactionHelper transactionsHelper, // Interface aqui
        ICreateEnderecoUseCase createEnderecoUseCase, 
        IGetEstabelecimentoIdUseCase getEstabelecimentoIdUseCase, 
        IPedidoRepository repository)
    {
        _createProdutoPedidoUseCase = createProdutoPedidoUseCase;
        _dbTransactionsHelper = transactionsHelper;
        _createEnderecoUseCase = createEnderecoUseCase;
        _repository = repository;
        _getEstabelecimentoIdUseCase = getEstabelecimentoIdUseCase;
    }

    public async Task<Token?> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto)
    {
        await _dbTransactionsHelper.BeginTransactionAsync();

        try
        {
            var estabelecimentoId = await _getEstabelecimentoIdUseCase.Execute(estabelecimentoSlug);
            if (estabelecimentoId == null)
            {
                await _dbTransactionsHelper.RollbackTransactionAsync();
                throw new Exception(message: "Erro ao salvar!");
                return null;
            }

            // 2. Criar Pedido Base
            var pedido = PedidoMapper.CreatePedidoDto_To_PedidoEntity(pedidoDto, estabelecimentoId.Value);
            var pedidoCadastradoId = await _repository.CreatePedido(pedido);
            
            if (pedidoCadastradoId == null)
            {
                await _dbTransactionsHelper.RollbackTransactionAsync();
                throw new Exception(message: "Erro ao salvar!");
                return null;
            }

            CreateEnderecoDTO endereco = pedidoDto.Endereco;
            // Nota: Verifique se aqui não deveria ser o ID do Pedido ou ID do Usuário
            await _createEnderecoUseCase.Execute(endereco, (int)pedidoCadastradoId);
            await _createProdutoPedidoUseCase.Execute(pedidoDto.ProdutoPedidos, (int)pedidoCadastradoId, (int)estabelecimentoId);

            await _dbTransactionsHelper.CommitTransactionAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sua_chave_secreta_super_segura_aqui");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", pedidoCadastradoId.ToString()!) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new Token(){token = tokenString};
        }
        catch (Exception)
        {
            await _dbTransactionsHelper.RollbackTransactionAsync();
                throw new Exception(message: "Erro ao salvar!");
            // Logar o erro aqui (ex: ILogger)
            return null;
        }
    }
}