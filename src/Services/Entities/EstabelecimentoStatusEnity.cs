using Comaagora_API.src.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;

namespace Comaagora_API.Entities;

[Table("EstabelecimentoStatus")]
public partial class EstabelecimentoStatusEnity : BaseEntity
{

    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = null!;
    [Required]
    [StringLength(20)]
    public string Codigo { get; set; } = null!;

    public virtual ICollection<EstabelecimentosEntity> Estabelecimentos { get; set; } = new List<EstabelecimentosEntity>();
}
