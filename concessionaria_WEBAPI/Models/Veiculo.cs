using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concessionaria_WEBAPI.Models;

public class Veiculo
{
    //Primary Key Veiculo
    [Key]
    public string? Placa { get; set; }

    //Foreign Key Protocolo 
    [ForeignKey("Protocolo")]
    public string? Protocolo { get; set; }

    //Attributes
    public string? Modelo { get; set; }
    public double? Valor { get; set; }
    public string? Status { get; set; }
    public string? Descricao { get; set; }
}