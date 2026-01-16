using Comaagora_API.src.Application.DTOs;
using Comaagora_API.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Comaagora_API.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly IGetCategoriasUseCase  _getCategoriasUseCase;

    public CategoriaController (IGetCategoriasUseCase getCategoriasUseCase)
    {
        _getCategoriasUseCase = getCategoriasUseCase;
    }
    [HttpGet]
    public async Task<ActionResult<List<GetCategoriaProdutoDTO>>> GetCategorias([FromQuery] string estabelecimentoSlug)
    {

        if (string.IsNullOrEmpty(estabelecimentoSlug))
        {
            return BadRequest("Establishment slug is required.");
        }

        var result = await _getCategoriasUseCase.Execute(estabelecimentoSlug);
        
         if (result == null || result.Count <= 0)
         {
             return NotFound("Establishment slug not found.");
         }
         else
         {
             return Ok(result);
         }
    }
}