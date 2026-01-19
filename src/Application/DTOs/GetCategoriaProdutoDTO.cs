namespace Comaagora_API.src.Application.DTOs;

public class GetCategoriaProdutoDTO
{
    public int id {get; }
    public string categoria { get; }

    public GetCategoriaProdutoDTO(int id, string categoria)
    {
        this.id = id;
        this.categoria = categoria;
    }
}