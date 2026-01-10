using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Services.Entities;

namespace Comaagora_API.Entities;

[Table("ProdutoStatus")]
public partial class ProdutoStatusEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)] // Ex: "Disponível", "Indisponível", "Racionado"
    public string Nome { get; set; } = null!;

    [Required]
    public int StatusId { get; set; }

    [Required]
    public int EstabelecimentoId { get; set; }

    // --- Relacionamentos e Navegação ---

    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public virtual StatusEntity Status { get; set; } = null!;

    public virtual ICollection<ProdutoEntity> Produtos { get; set; } = new List<ProdutoEntity>();
}