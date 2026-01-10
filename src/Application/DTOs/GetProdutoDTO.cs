using System.Diagnostics.CodeAnalysis;

namespace Comaagora_API.src.Application.DTOs
{
    public class GetProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImgUrl { get; set; }
        public decimal Preco { get; set; }

        public GetProdutoDTO(int Id, string nome, decimal preco, string imgUrl, string descricao)
        {
            this.Id = Id;
            this.Nome = nome;
            this.Preco = preco;
            this.ImgUrl = imgUrl;
            this.Descricao = descricao;
        }
        
    }
}
