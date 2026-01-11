using Comaagora_API.Data.Interfaces;
using Comaagora_API.Services.Interfaces;

namespace Comaagora_API.Services.UseCases;

public class GetEstabeleicmentoIdUseCase : IGetEstabelecimentoId
{
    private readonly IEstabelecimentoRepository _estabelecimentoRepository;
    public GetEstabeleicmentoIdUseCase(IEstabelecimentoRepository estabelecimentoRepository){
        _estabelecimentoRepository = estabelecimentoRepository;
    }
    public async Task<int?> GetEstabelecimentoId(string estabelecimentoSlug)
    {
        var estabelecimentoId = await _estabelecimentoRepository
            .GetEstabelecimentoId(estabelecimentoSlug);

        if (estabelecimentoId == null) return null;
        return estabelecimentoId;
    }
}