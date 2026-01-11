using Comaagora_API.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IGetProdutosUseCase _getProdutosUseCase;

        public ProdutoController(IGetProdutosUseCase getProdutosUseCase)
        {
            _getProdutosUseCase = getProdutosUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProdutoDTO>>> GetProdutos(
            [FromQuery] string estabelecimentoSlug)
        {
            if (string.IsNullOrWhiteSpace(estabelecimentoSlug))
                return BadRequest("O slug do estabelecimento é obrigatório.");

            var produtos = await _getProdutosUseCase.Execute(estabelecimentoSlug);

            if (produtos == null || produtos.Count == 0)
                return NotFound("Nenhum produto encontrado para este estabelecimento.");

            return Ok(produtos);
        }
    }
}
