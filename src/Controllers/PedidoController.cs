using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ICreatePedidoUseCase _createPedidoUseCase;

    public PedidoController(ICreatePedidoUseCase createPedidoUseCase)
    {
        _createPedidoUseCase = createPedidoUseCase;
    }
    [HttpPost]
    public async Task<ActionResult<CreatePedidoDTO>> CreatePedido(
            [FromQuery]string  estabelecimentoSlug,
            [FromBody]CreatePedidoDTO pedido)
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
}
    