using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreatePedidoUseCase
{
    public Task<Token?> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto);
}