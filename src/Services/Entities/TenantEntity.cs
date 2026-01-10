using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comaagora_API.Services.Entities;
using Comaagora_API.src.Services.Entities;

namespace Comaagora_API.Entities;

[Table("Tenants")]
public partial class TenantEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ContratanteId { get; set; }

    [Required]
    [StringLength(50)] // Ex: "Bronze", "Prata", "Ouro", "Enterprise"
    public string Plano { get; set; } = null!;

    [Required]
    [StringLength(20)] // Ex: "Ativo", "Suspenso", "Inadimplente"
    public string Status { get; set; } = null!;

    public byte[]? ContratoAnexo { get; set; }

    [StringLength(10)] // Ex: ".pdf", ".jpg"
    public string? TipoArquivo { get; set; }

    // --- Relacionamentos ---

    public virtual ICollection<EstabelecimentosEntity> Estabelecimentos { get; set; } = new List<EstabelecimentosEntity>();
}