using Comaagora_API.Application.Utils;
using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<string>> CreatePedido(
        [FromQuery] string estabelecimentoSlug,
        [FromBody] CreatePedidoDTO pedido,
        [FromHeader] string? token)
    {
        try
        {
            var validar = new TokenValidation();
            if (string.IsNullOrEmpty(token) || validar.TokenExpirou(token!) == true)
            {
                var resultado = await _createPedidoUseCase.Execute(estabelecimentoSlug, pedido);
                if (!string.IsNullOrEmpty(resultado))
                {
                    return Ok(resultado);
                }
            }
            var r = await _createPedidoUseCase.Execute(estabelecimentoSlug, pedido, token);
            if (!string.IsNullOrEmpty(r))
            {
                return Ok(r);
            }
            throw new Exception("Erro interno do servidor");
        }
        catch (Exception e)
        {
            throw new Exception("Erro interno do servidor");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<GetPedidoDTO>>> GetPedidosBySessionToken(
        [FromHeader] string token
    )
    {
        try
        {
            if (!string.IsNullOrEmpty(token))
            {
                var resultado = await _getPedidoUseCase.Execute(token);
                return Ok(resultado);
            }

            return BadRequest("Informe token");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<List<GetPedidoDTO>>> GetPedidosByPedidoId(int id)
    {
        try
        {
            if (id != null)
            {
                var resultado = await _getPedidoUseCase.Execute(id);
                return Ok(resultado);
            }

            return BadRequest("Código de pedido inválido");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
    