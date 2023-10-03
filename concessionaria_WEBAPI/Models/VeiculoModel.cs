/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concessionaria_WEBAPI.Models;

public class VeiculoModel
{
    //Primary Key Veiculo
    [Key]
    public string? PlacaVeiculo { get; set; }

    //Foreign Key Protocolo 
    [ForeignKey("Protocolo")]
    public string? Protocolo { get; set; }

    //Attributes

    public int AnoVeiculo { get; set; }
    public string? ModeloVeiculo { get; set; }
    public double Valor { get; set; }
    public string? Status { get; set; }
    public string? Descricao { get; set; }
}
*/