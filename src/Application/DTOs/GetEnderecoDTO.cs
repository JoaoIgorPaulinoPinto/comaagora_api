namespace Comaagora_API.src.Application.DTOs;

public class GetEnderecoDTO
{
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Complemento { get; set; }
}