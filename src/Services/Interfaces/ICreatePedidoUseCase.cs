using Comaagora_API.Services.Models;
using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces;

public interface ICreatePedidoUseCase
{
    public Task<string?> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto);
    public Task<string?> Execute(string estabelecimentoSlug, CreatePedidoDTO pedidoDto, string token);
}