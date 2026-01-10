using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Data.Interfaces;

public interface IEstabelecimentoRepository
{
    public Task<GetEstabelecimentoDTO?> GetEstabelecimentoData(string estabelecimentoSlug);
    public Task<int?> GetEstabelecimentoId(string estabelecimentoSlug) ;
}