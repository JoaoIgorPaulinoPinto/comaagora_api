using Comaagora_API.src.Services.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;

namespace Comaagora_API.Entities;

[Table("MetodoPagamento")]
public partial class MetodoPagamentoEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = null!;
    [Required]
    [StringLength(100)]
    public string Tipo { get; set; } = null!;
    [Required]
    public bool Ativo { get; set; }
    [Required]
    public int EstabelecimentoId { get; set; }
    [Required]
    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;
    public virtual ICollection<PedidoEntity> Pedidos { get; set; } = new List<PedidoEntity>();
}
