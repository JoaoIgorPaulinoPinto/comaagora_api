using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Entities;
using Comaagora_API.src.Services.Entities;

// Certifique-se que o caminho está correto

namespace Comaagora_API.Services.Entities;

[Table("Estabelecimentos")]
public partial class EstabelecimentosEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Slug { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string NomeFantasia { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string RazaoSocial { get; set; } = null!;

    [Required]
    [StringLength(14)] // CNPJ apenas números
    public string Cnpj { get; set; } = null!;

    [Required]
    [StringLength(20)]
    [Phone]
    public string Telefone { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Whatsapp { get; set; } = null!;

    [Required]
    public int EstabelecimentoStatusId { get; set; }

    [Required]
    public int TenantId { get; set; }

    [Required]
    public decimal TaxaEntrega { get; set; }

    [Required]
    public decimal PedidoMinimo { get; set; }

    // --- Relacionamentos e Navegação ---

    [ForeignKey(nameof(EstabelecimentoStatusId))]
    public virtual EstabelecimentoStatusEnity EstabelecimentoStatus { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual TenantEntity Tenant { get; set; } = null!;

    public virtual ICollection<EstabecimentoCategoriaEntity> EstabelecimentoCategoria { get; set; } = new List<EstabecimentoCategoriaEntity>();
    public virtual ICollection<HorarioFuncionamentoEnity> HorarioFuncionamentos { get; set; } = new List<HorarioFuncionamentoEnity>();
    public virtual ICollection<MetodoPagamentoEntity> MetodoPagamentos { get; set; } = new List<MetodoPagamentoEntity>();
    public virtual ICollection<PedidoStatusEntity> PedidoStatuses { get; set; } = new List<PedidoStatusEntity>();
    public virtual ICollection<PedidoEntity> Pedidos { get; set; } = new List<PedidoEntity>();
    public virtual ICollection<ProdutoCategoriaEntity> ProdutoCategoria { get; set; } = new List<ProdutoCategoriaEntity>();
    public virtual ICollection<ProdutoPedidoEntity> ProdutoPedidos { get; set; } = new List<ProdutoPedidoEntity>();
    public virtual ICollection<ProdutoStatusEntity> ProdutoStatuses { get; set; } = new List<ProdutoStatusEntity>();
    public virtual ICollection<ProdutoEntity> Produtos { get; set; } = new List<ProdutoEntity>();
    public virtual ICollection<StatusEntity> Statuses { get; set; } = new List<StatusEntity>();
    public virtual ICollection<UnidadeMedidaEntity> UnidadeMedida { get; set; } = new List<UnidadeMedidaEntity>();
}