using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Services.Entities;

namespace Comaagora_API.Entities;

[Table("Status")]
public partial class StatusEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [Required]
    [StringLength(30)] // Geralmente códigos são curtos e em caixa alta
    public string Codigo { get; set; } = null!;

    [Required]
    public int EstabelecimentoId { get; set; }

    // --- Relacionamentos e Navegação ---

    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;

    // Coleções de referência
    public virtual ICollection<EstabecimentoCategoriaEntity> EstabelecimentoCategoria { get; set; } = new List<EstabecimentoCategoriaEntity>();
    public virtual ICollection<PedidoStatusEntity> PedidoStatuses { get; set; } = new List<PedidoStatusEntity>();
    public virtual ICollection<ProdutoCategoriaEntity> ProdutoCategoria { get; set; } = new List<ProdutoCategoriaEntity>();
    public virtual ICollection<ProdutoStatusEntity> ProdutoStatuses { get; set; } = new List<ProdutoStatusEntity>();
}