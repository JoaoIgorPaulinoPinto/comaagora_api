using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;

namespace Comaagora_API.Entities;


[Table("HorarioFuncionamento")]
public partial class HorarioFuncionamentoEnity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int EstabelecimentoId { get; set; }
    [Required]
    public string DiaSemana { get; set; } = null!;
    [Required]
    public TimeOnly Abertura { get; set; }
    [Required]
    public TimeOnly Fechamento { get; set; }
    [Required]
    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;
}
