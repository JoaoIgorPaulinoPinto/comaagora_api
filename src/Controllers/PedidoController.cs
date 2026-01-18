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
        if (string.IsNullOrEmpty(estabelecimentoSlug))
            return BadRequest("Slug inválido");

        var validar = new TokenValidation();
        bool tokenInvalido = string.IsNullOrEmpty(token) || validar.TokenExpirou(token);

        try
        {
            string resultado;

            if (tokenInvalido)
            {
                // gera novo token
                resultado = await _createPedidoUseCase.Execute(estabelecimentoSlug, pedido);
            }
            else
            {
                // usa token existente
                resultado = await _createPedidoUseCase.Execute(estabelecimentoSlug, pedido, token);
            }

            if (string.IsNullOrEmpty(resultado))
                return StatusCode(500, "Erro ao criar pedido");

            return Ok(resultado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno do servidor");
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
    