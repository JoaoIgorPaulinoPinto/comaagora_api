namespace Comaagora_API.src.Application.DTOs;

public class CreateEnderecoDTO
{
    
    public int UsuarioId { get; set; }
    public int UfId { get; set; }
    public int CidadeId { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Complemento { get; set; }
}   