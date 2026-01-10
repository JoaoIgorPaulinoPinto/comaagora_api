namespace Comaagora_API.src.Application.DTOs;

public class GetPedidoDTO
{
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public string MetodoPagamento { get; set; }
    public List<CreateProdutoPedidoDTO> ProdutoPedidos { get; set; }
    public string Observacao { get; set; }
    public string Status;
    public int Id;
}