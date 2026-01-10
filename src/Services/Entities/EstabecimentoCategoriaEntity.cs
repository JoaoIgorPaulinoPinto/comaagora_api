using Comaagora_API.src.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;

namespace Comaagora_API.Entities;

[Table("EstabelecimentoCategoria")]
public partial class EstabecimentoCategoriaEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = null!;
    [Required]
    public int StatusId { get; set; }
    [Required]
    public int EstabelecimentoId { get; set; }

    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;
    [ForeignKey(nameof(StatusId))]
    public virtual StatusEntity Status { get; set; } = null!;
}
