namespace Comaagora_API.src.Application.DTOs;

public class GetHorarioFuncionamentoDTO
{
   public string DiaSemana { get; set; } = null!;
    public TimeOnly Abertura { get; set; }
    public TimeOnly Fechamento { get; set; }
}