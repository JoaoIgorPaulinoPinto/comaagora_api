using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Services.Entities;

namespace Comaagora_API.Entities;

[Table("Produtos")]
public partial class ProdutoEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(500)]
    public string Descricao { get; set; } = null!;

    [StringLength(255)]
    public string ImgUrl { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }

    [Required]
    public int UnidadeMedidaId { get; set; }

    [Required]
    public int EstabelecimentoId { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    [Required]
    public int ProdutoStatusId { get; set; }

    // Recomendo alterar para bool, mas mantendo a lógica de int:
    public int? Ativo { get; set; }

    // --- Relacionamentos e Navegação ---

    [ForeignKey(nameof(CategoriaId))]
    public virtual ProdutoCategoriaEntity Categoria { get; set; } = null!;

    [ForeignKey(nameof(EstabelecimentoId))]
    public virtual EstabelecimentosEntity Estabelecimento { get; set; } = null!;

    [ForeignKey(nameof(ProdutoStatusId))]
    public virtual ProdutoStatusEntity ProdutoStatus { get; set; } = null!;

    [ForeignKey(nameof(UnidadeMedidaId))]
    public virtual UnidadeMedidaEntity UnidadeMedida { get; set; } = null!;

    public virtual ICollection<ProdutoPedidoEntity> ProdutoPedidos { get; set; } = new List<ProdutoPedidoEntity>();
}