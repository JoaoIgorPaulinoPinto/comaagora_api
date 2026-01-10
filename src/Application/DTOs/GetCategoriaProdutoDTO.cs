namespace Comaagora_API.src.Application.DTOs;

public class GetCategoriaProdutoDTO
{
    public int id {get; set;}
    public string categoria { get; set; }

    public GetCategoriaProdutoDTO(int id, string categoria)
    {
        this.id = id;
        this.categoria = categoria;
    }
}