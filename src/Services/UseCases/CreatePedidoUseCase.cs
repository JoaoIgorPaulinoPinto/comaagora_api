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

    public async Task<string> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto)
    {
        await _dbTransactionsHelper.BeginTransactionAsync();

        try
        {
            var estabelecimentoId = await _getEstabelecimentoIdUseCase.Execute(estabelecimentoSlug);
            if (estabelecimentoId == null)
                throw new Exception("Estabelecimento não encontrado");

            var pedido = PedidoMapper.CreatePedidoDto_To_PedidoEntity(pedidoDto, estabelecimentoId.Value);
            var pedidoCadastradoId = await _repository.CreatePedido(pedido, null);
            if (pedidoCadastradoId == null)
                throw new Exception("Erro ao criar pedido");

            int pedidoId = pedidoCadastradoId.Value;
            int estabId = estabelecimentoId.Value;

            await _createEnderecoUseCase.Execute(pedidoDto.Endereco, pedidoId);
            await _createProdutoPedidoUseCase.Execute(pedidoDto.ProdutoPedidos, pedidoId, estabId);

            await _dbTransactionsHelper.CommitTransactionAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sua_chave_secreta_super_segura_aqui");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", pedidoId.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return  tokenString ;
        }
        catch (Exception ex)
        {
            await _dbTransactionsHelper.RollbackTransactionAsync();
            throw new Exception("Erro ao salvar pedido", ex);
        }
    }

    public async Task<string> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto, string t)
    {
        await _dbTransactionsHelper.BeginTransactionAsync();

        try
        {
            var estabelecimentoId = await _getEstabelecimentoIdUseCase.Execute(estabelecimentoSlug);
            if (estabelecimentoId == null)
                throw new Exception("Estabelecimento não encontrado");

            var pedido = PedidoMapper.CreatePedidoDto_To_PedidoEntity(pedidoDto, estabelecimentoId.Value);
            var pedidoCadastradoId = await _repository.CreatePedido(pedido, null);
            if (pedidoCadastradoId == null)
                throw new Exception("Erro ao criar pedido");

            int pedidoId = pedidoCadastradoId.Value;
            int estabId = estabelecimentoId.Value;

            await _createEnderecoUseCase.Execute(pedidoDto.Endereco, pedidoId);
            await _createProdutoPedidoUseCase.Execute(pedidoDto.ProdutoPedidos, pedidoId, estabId);

            await _dbTransactionsHelper.CommitTransactionAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sua_chave_secreta_super_segura_aqui");

            if (string.IsNullOrEmpty(t))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", pedidoId.ToString()) }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                 var token = tokenHandler.CreateToken(tokenDescriptor);
                 var tokenString = tokenHandler.WriteToken(token);
                return tokenString;
            }
            return t;

        }
        catch (Exception ex)
        {
            await _dbTransactionsHelper.RollbackTransactionAsync();
            throw new Exception("Erro ao salvar pedido", ex);
        }
    }
}