namespace Comaagora_API.Services.Interfaces;

public interface IGetEstabelecimentoIdUseCase
{
      public Task<int?> Execute(string estabelecimentoSlug);
}                       