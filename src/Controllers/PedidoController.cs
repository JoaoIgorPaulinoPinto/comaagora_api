using Comaagora_API.Services.Interfaces;
using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ICreatePedidoUseCase _createPedidoUseCase;
    private readonly IGetPedidosUseCase _getPedidoUseCase;

    public PedidoController(ICreatePedidoUseCase createPedidoUseCase, IGetPedidosUseCase getPedidoUseCase)
    {
        _createPedidoUseCase = createPedidoUseCase;
        _getPedidoUseCase = getPedidoUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<Token>> CreatePedido(
        [FromQuery] string estabelecimentoSlug,
        [FromBody] CreatePedidoDTO pedido)
    {
        try
        {
            var resultado = await _createPedidoUseCase.Execute(estabelecimentoSlug, pedido);

            return Ok(resultado);
        }
        catch (Exception e)
        {
            throw new Exception("Erro interno do servidor");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<GetPedidoDTO>>> GetPedidos(
        [FromQuery] string token,
        [FromQuery] int pedidoCodigo
        )
    {
        try
        {
            if (token != null && token != "" )
            {
                var resultado = await _getPedidoUseCase.Execute(token);
                Response.Cookies.Append("session_token", token, new CookieOptions
                {
                    HttpOnly = true, // Impede JS de ler
                    Secure = true, // Apenas envia em HTTPS
                    SameSite = SameSiteMode.Strict // Protege contra CSRF
                });
                return Ok(resultado);
            }
            else if(pedidoCodigo != null){
                var resultado = await _getPedidoUseCase.Execute(pedidoCodigo);
                return Ok(resultado);
            }
            else
            {
                throw new Exception("Erro interno do servidor");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Erro interno do servidor");
        }
    }
}
    