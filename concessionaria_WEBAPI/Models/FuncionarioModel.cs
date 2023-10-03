using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;

public class FuncionarioModel
{
    [Key]
    public int IdFuncionario { get; set; } 
    public string? Cpf { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public double Salario { get; set; }
    public int? AnoContratatado { get; set; }
}
