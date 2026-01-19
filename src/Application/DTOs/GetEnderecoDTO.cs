namespace Comaagora_API.src.Application.DTOs;

public class GetEnderecoDTO
{
    public string Uf { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Rua { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
}