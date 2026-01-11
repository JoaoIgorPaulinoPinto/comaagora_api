namespace Comaagora_API.Services.Interfaces;

public interface IGetEstabelecimentoId
{
      public Task<int?> GetEstabelecimentoId(string estabelecimentoSlug);
}