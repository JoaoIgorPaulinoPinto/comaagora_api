using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstadosController : ControllerBase
{

    private readonly IGetEstadosUseCase _getEstadosUseCase;

   
    public EstadosController(IGetEstadosUseCase useCase)
    {
        _getEstadosUseCase = useCase;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetEstadoDTO>>> Get()
    {
        return await _getEstadosUseCase.Execute();
    }
}