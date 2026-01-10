using Comaagora_API.Entities;
using Comaagora_API.src.Services.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Enderecos")]
public partial class EnderecoEntity : BaseEntity
{


    [Key]
    public int Id { get; set; }

    [Required]
    public int Usuario { get; set; }

    [Required]
    public int Tipo { get; set; }

    [Required]
    [StringLength(8), MinLength(8)] 
    public string Cep { get; set; } = null!;

    [Required]
    public int Uf { get; set; }

    [Required]
    public int Cidade { get; set; }

    [Required]
    [StringLength(100)]
    public string Rua { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string Numero { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Bairro { get; set; } = null!;

    [StringLength(100)]
    public string? Complemento { get; set; } 

    // --- Propriedades de Navegação (Relacionamentos) ---

    [ForeignKey(nameof(Cidade))]
    public virtual MunicipioEntity CidadeEntity { get; set; } = null!;

    [ForeignKey(nameof(Tipo))]
    public virtual TipoEnderecoEntity TipoEntity { get; set; } = null!;

    [ForeignKey(nameof(Uf))]
    public virtual EstadoEnity UfEntity { get; set; } = null!;


    public EnderecoEntity(int usuario,int tipo, string cep, int uf, int cidade, string rua, string numero, string bairro, string? complemento)
    {
        Usuario = usuario;
        Cep = cep;
        Uf = uf;
        Cidade = cidade;
        Rua = rua;
        Numero = numero;
        Bairro = bairro;
        Complemento = complemento;
        Tipo = tipo;
    }
}