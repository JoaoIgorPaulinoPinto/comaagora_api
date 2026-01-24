using Comaagora_API.Services.Interfaces;
using Comaagora_API.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MunicipioController: ControllerBase
{
    private readonly IGetCidadesUseCase _getMunicipiosUseCase;


    public MunicipioController(IGetCidadesUseCase usecase)
    {
        _getMunicipiosUseCase = usecase;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCidadeDTO>>> Get([FromQuery] int UfId)
    {
       return await _getMunicipiosUseCase.Execute(UfId);
    }
}