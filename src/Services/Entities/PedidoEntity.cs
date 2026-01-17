using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Services.Entities;

namespace Comaagora_API.Entities;

[Table("Pedidos")]
public partial class PedidoEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int EstabelecimentoId { get; set; }

    [Required]
    public int MetodoPagamentoId { get; set; }

    [StringLength(500)]
    public string? Observacao { get; set; } // Tornou-se opcional e com limite

    [Required]
    [StringLength(150)]
    public string NomeCliente { get; set; } = null!;

    [Required]
    [StringLength(20)]
    [Phone]
    public string TelefoneCliente { get; set; } = null!;

    public int PedidoStatusId { get; set; } = 1; 
    
    [Required]
    [StringLength(255)]
    public string SessionToken { get; set; } = null!;
    // --- Relacionamentos e Navegação ---

    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;

    [ForeignKey(nameof(MetodoPagamentoId))]
    public virtual MetodoPagamentoEntity MetodoPagamento { get; set; } = null!;

    [ForeignKey(nameof(PedidoStatusId))]
    public virtual PedidoStatusEntity PedidoStatus { get; set; } = null!;

    public virtual ICollection<ProdutoPedidoEntity> ProdutoPedidos { get; set; } = new List<ProdutoPedidoEntity>();
}