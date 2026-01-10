using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comaagora_API.Entities;
[Table("Municipio")]

public partial class MunicipioEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(11)]
    public int Codigo { get; set; }
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = null!;
    [Required]
    [StringLength(2)]
    public string Uf { get; set; } = null!;

    public virtual ICollection<EnderecoEntity> Enderecos { get; set; } = new List<EnderecoEntity>();
}
