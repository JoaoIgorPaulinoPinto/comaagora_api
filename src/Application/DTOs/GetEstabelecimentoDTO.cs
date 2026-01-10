using Comaagora_API.Entities;

namespace Comaagora_API.src.Application.DTOs;

public class GetEstabelecimentoDTO
{
    public string Nome { get; set; } = string.Empty;
    public List<GetHorarioFuncionamentoDTO> HorarioFuncionamento { get; set; }
    public decimal TaxaEntrega { get; set; }
    public decimal PedidoMinimo { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Whatsapp { get; set; } = string.Empty;
    public GetEnderecoDTO? Endereco;
}