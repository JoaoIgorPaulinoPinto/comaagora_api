using Comaagora_API.src.Application.DTOs;
using Comaagora_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Comaagora_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstabelecimentoController:ControllerBase
{
    private readonly IGetEstabelecimentoUseCase _getEstabelecimentoUseCaseUseCase;

    public EstabelecimentoController   (IGetEstabelecimentoUseCase getUseCaseUseCase)
    {
        _getEstabelecimentoUseCaseUseCase = getUseCaseUseCase;
    }
    [HttpGet]
    public async Task<ActionResult<GetEstabelecimentoDTO>> GetEstabelecimento([FromQuery]string estabelecimentoSlug)
    {
        if (estabelecimentoSlug.IsNullOrEmpty())
        {   
            return BadRequest("o slug do estabelecimento é necessário");
        }
        var result = await _getEstabelecimentoUseCaseUseCase.Execute(estabelecimentoSlug);
        if (result == null)
        {
            throw new Exception("Nenhum estabelecimento foi encontrado.");
        }
        return Ok(result);
    }                              
}