using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concessionaria_WEBAPI.Models;

public class VeiculoModel
{
    private int _idVeiculo;

    //Primary Key Veiculo
    [Key]
    public int IdVeiculo{
        get => _idVeiculo;
        set => _idVeiculo = value;
    }
    
    //Attributes
    public enum StatusVeiculo { DISPONIVEL, ALUGADO, VENDIDO };
    public string? Nome {get; set;}
    public string? PlacaVeiculo { get; set; }
    public int AnoVeiculo { get; set; }
    public string? ModeloVeiculo { get; set; }
    public string? Valor { get; set; }
    public string? TipoVeiculo { get; set; }   //Descrição do veículo = Carro ou moto
    public StatusVeiculo Status {get; set;}
    public int? PedidoId {get;set;}
}
