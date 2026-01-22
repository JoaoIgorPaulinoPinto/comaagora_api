namespace Comaagora_API.src.Application.DTOs;

public class GetPedidoDTO
{
    public string Status { get; set; }
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public string MetodoPagamento { get; set; }
    public List<GetProdutoPedidoDTO> ProdutoPedidos { get; set; }
    public string Observacao { get; set; }
    public GetEnderecoDTO Endereco { get; set; }
    public decimal TaxaEntrega { get; set; }
    public decimal ValorTotal { get; set; }
}