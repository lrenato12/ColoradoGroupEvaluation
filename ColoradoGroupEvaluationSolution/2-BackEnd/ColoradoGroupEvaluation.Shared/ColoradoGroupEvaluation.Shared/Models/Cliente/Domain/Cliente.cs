﻿namespace ColoradoGroupEvaluation.Shared.Models.Cliente.Domain;

public class Cliente
{
    public int CodigoCliente { get; set; }
    public string RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public string TipoPessoa { get; set; }
    public string Documento { get; set; }
    public string Endereco { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }
    public string UF { get; set; }
    public DateTime DataInsercao { get; set; }
    public string UsuarioInsercao { get; set; }
    public virtual ICollection<Telefone.Domain.Telefone> Telefones { get; set; }

    public Cliente()
    {
        Telefones = new HashSet<Telefone.Domain.Telefone>();
    }
}