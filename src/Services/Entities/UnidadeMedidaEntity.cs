using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;

namespace Comaagora_API.Entities;

[Table("UnidadeMedida")]
public partial class UnidadeMedidaEntity
{
    [Key]
    public int Id { get; set; }

    [Column("UnidadeMedida")]
    [StringLength(20)]
    public string NomeUnidade { get; set; } = null!;
    [Required]
    public int Ativo { get; set; }
    [Required]
    public int EstabelecimentoId { get; set; }
    [Required]
    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;

    public virtual ICollection<ProdutoEntity> Produtos { get; set; } = new List<ProdutoEntity>();
}
