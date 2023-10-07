using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;

public class FuncionarioModel
{
    private int _idFuncionario;
    private string? _cpf;
    
    [Key]
    public int IdFuncionario {
        get => _idFuncionario;
        set => _idFuncionario = value;} 
    public string? Cpf { 
        get => _cpf; 
        set => _cpf = value; 
    }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public string? Salario { get; set; }
    public int? AnoContratatado { get; set; }
}
