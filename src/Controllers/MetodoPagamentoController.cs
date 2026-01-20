using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetodoPagamentoController :ControllerBase
{
    private readonly IGetMetodoPagamentoUseCase _getMetodoPagamentoUseCase;

    public MetodoPagamentoController(IGetMetodoPagamentoUseCase getMetodoPagamentoUseCase)
    {
        _getMetodoPagamentoUseCase = getMetodoPagamentoUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetMetodoPagamentoDTO>>> Get(string estabelecimentoSlug)
    {
        try
        {
            var r = _getMetodoPagamentoUseCase.Execute(estabelecimentoSlug).Result;
            return Ok(r);
        }
        catch
        {
            return NotFound();
        }
    }
}