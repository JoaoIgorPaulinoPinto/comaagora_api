using Comaagora_API.src.Application.DTOs;

namespace Comaagora_API.Application.Mappers;

public class EnderecoMapper
{
    public static EnderecoEntity CreateEnderecoDto_To_EnderecoEntity(CreateEnderecoDTO enderecoDTO, int pedidoId)
    {
        var entityEnedereco = new EnderecoEntity(
            pedidoId,
            1, // tipo usuario cliente
            enderecoDTO.Cep,
            enderecoDTO.UfId,
            enderecoDTO.CidadeId,
            enderecoDTO.Rua,
            enderecoDTO.Numero,
            enderecoDTO.Bairro,
            enderecoDTO.Complemento
        );
        return  entityEnedereco;
    }

    public static GetEnderecoDTO EnderecoEntity_To_GetEnderecoDto(EnderecoEntity endereco)
    {
        var dtoEndereco = new GetEnderecoDTO {  
            Rua = endereco.Rua,
            Numero = endereco.Numero,
            Bairro = endereco.Bairro,
            Cidade = endereco.CidadeEntity.Nome,
            Uf = endereco.UfEntity.Nome,
            Cep = endereco.Cep
        };
        return dtoEndereco;
    }
}