using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Services.Interfaces
{
    public interface IGetEstabelecimentoUseCase
    {
        public Task<GetEstabelecimentoDTO> Execute(string estabelecimentoSlug);
    }
}

    
