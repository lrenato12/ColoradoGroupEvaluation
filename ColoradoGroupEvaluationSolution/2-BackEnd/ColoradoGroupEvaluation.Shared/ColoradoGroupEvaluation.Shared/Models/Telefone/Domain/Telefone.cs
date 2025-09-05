namespace ColoradoGroupEvaluation.Shared.Models.Telefone.Domain;

public class Telefone
{
    public int CodigoTelefone { get; set; }
    public int CodigoCliente { get; set; }
    public string? NumeroTelefone { get; set; }
    public int CodigoTipoTelefone { get; set; }
    public string? Operadora { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataInsercao { get; set; }
    public string? UsuarioInsercao { get; set; }
    public required virtual Cliente.Domain.Cliente Cliente { get; set; }
    public required virtual TipoTelefone.Domain.TipoTelefone TipoTelefone { get; set; }
}