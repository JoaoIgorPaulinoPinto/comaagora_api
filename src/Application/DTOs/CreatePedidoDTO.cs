namespace Comaagora_API.src.Application.DTOs;

public class CreatePedidoDTO
{
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public int MetodoPagamento { get; set; }
    public List<CreateProdutoPedidoDTO> ProdutoPedidos { get; set; }
    public string Observacao { get; set; }
    public CreateEnderecoDTO Endereco { get; set; }
}                          