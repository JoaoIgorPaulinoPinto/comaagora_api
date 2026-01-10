using Comaagora_API.src.Services.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comaagora_API.Entities;

[Table("Estado")]
public partial class EstadoEnity : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int CodigoUf { get; set; }
    [Required]
    public string Nome { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string Uf { get; set; } = null!;
    [Required]
    public int Regiao { get; set; }
    public virtual ICollection<EnderecoEntity> Enderecos { get; set; } = new List<EnderecoEntity>();
}
