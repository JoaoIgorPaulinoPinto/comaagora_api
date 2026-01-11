using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;

namespace Comaagora_API.Services.UseCases;

public class GetEstabeleicmentoIdUseCase : IGetEstabelecimentoIdUseCase
{
    private readonly IEstabelecimentoRepository _repository;
    public GetEstabeleicmentoIdUseCase(IEstabelecimentoRepository repository){
        _repository = repository;
    }
    public async Task<int?> Execute(string estabelecimentoSlug)
    {
        var estabelecimentoId = await _repository
            .GetEstabelecimentoId(estabelecimentoSlug);

        if (estabelecimentoId == null) return null;
        return estabelecimentoId;
    }
}