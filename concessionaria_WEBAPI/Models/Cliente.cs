using System.ComponentModel.DataAnnotations;
namespace concessionaria_WEBAPI.Models;

public class ClienteModel {
    [Key]
    public int Id {get; set;}
    public string? Cpf {get; set;}
    public string? Nome {get; set;}
    public string? Email {get; set;}
    public long Telefone {get; set;}
    public bool Ativo {get;set;}

    
}