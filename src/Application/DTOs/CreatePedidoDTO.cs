namespace Comaagora_API.src.Application.DTOs;

public class CreatePedidoDTO
{
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public int MetodoPagamento { get; set; }
    public List<CreateProdutoPedidoDTO> ProdutoPedidos { get; set; }
    public string Observacao { get; set; }
    public CreateEnderecoDTO Endereco { get; set; }
    public string? SessionToken { get; set; }

    public CreatePedidoDTO(string? sessionToken, string nomeCliente, string telefoneCliente, int metodoPagamento,  List<CreateProdutoPedidoDTO> produtoPedidos, string observacao, CreateEnderecoDTO endereco)
    {
        NomeCliente = nomeCliente;
        TelefoneCliente = telefoneCliente;
        MetodoPagamento = metodoPagamento;
        ProdutoPedidos = produtoPedidos;
        Observacao = observacao;
        Endereco = endereco;

        SessionToken = sessionToken;
    }
}                          