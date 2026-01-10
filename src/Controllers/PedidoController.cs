using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ICreatePedidoUseCase = _createPedidoUseCase

    public PedidoController(ICreatePedidoUseCase createPedidoUseCase)
    {
        _createPedidoUseCase = createPedidoUseCase;
    }
    [HttpGet]
    public Task<ActionResult<CreatePedidoDTO>> CreatePedido(
            [FromQuery]string  estabelecimentoSlug,
            [FromBody]CreatePedidoDTO pedido)
    {
        
        
    }
}
    