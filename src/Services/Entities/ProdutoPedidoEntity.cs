using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Services.Entities;

namespace Comaagora_API.Entities;

[Table("ProdutosPedidos")]
public partial class ProdutoPedidoEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public int EstabelecimentoId { get; set; }

    [Required]
    public int PedidoId { get; set; }

    [Required]
    public int ProdutoId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,3)")] // 3 casas para permitir frações (ex: 1.5kg)
    public decimal Quantidade { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecoUnitario { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }

    // --- Relacionamentos e Navegação ---

    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;

    [ForeignKey(nameof(PedidoId))]
    public virtual PedidoEntity Pedido { get; set; } = null!;

    [ForeignKey(nameof(ProdutoId))]
    public virtual ProdutoEntity Produto { get; set; } = null!;
}