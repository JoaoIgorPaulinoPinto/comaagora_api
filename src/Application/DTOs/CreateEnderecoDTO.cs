namespace Comaagora_API.src.Application.DTOs;

public class CreateEnderecoDTO
{
    public int UfId { get;  }
    public int CidadeId { get;  }
    public string Bairro { get;  }
    public string Numero { get;  }
    public string Cep { get;  }
    public string Rua { get;  }
    public string Complemento { get;  }

    public CreateEnderecoDTO(int ufId, int cidadeId, string bairro, string numero, string cep, string rua, string complemento)
    {
        UfId = ufId;
        CidadeId = cidadeId;
        Bairro =  bairro;
        Numero = numero;
        Cep = cep;
        Rua = rua;
        Complemento = complemento;
    }
}   