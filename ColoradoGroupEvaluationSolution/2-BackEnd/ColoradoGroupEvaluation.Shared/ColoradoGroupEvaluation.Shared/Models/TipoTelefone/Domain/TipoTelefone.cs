﻿namespace ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain;

public class TipoTelefone
{
    public int CodigoTipoTelefone { get; set; }
    public string DescricaoTipoTelefone { get; set; }
    public DateTime DataInsercao { get; set; }
    public string UsuarioInsercao { get; set; }
    
    public TipoTelefone()
    {

    }
}