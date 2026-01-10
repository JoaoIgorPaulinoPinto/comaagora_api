using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comaagora_API.Entities;

[Table("TipoEndereco")]
public partial class TipoEnderecoEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Tipo { get; set; } = null!;
    [Required]
    public int Ativo { get; set; }
    public virtual ICollection<EnderecoEntity> Enderecos { get; set; } = new List<EnderecoEntity>();
}
