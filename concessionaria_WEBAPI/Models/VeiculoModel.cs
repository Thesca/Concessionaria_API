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
    //Foreign Key Protocolo 
    //[ForeignKey("Protocolo")]
    //public id Pedido { get; set; }

    //Attributes
    public enum StatusVeiculo { DISPONIVEL, ALUGADO, VENDIDO };
    public string? PlacaVeiculo { get; set; }
    public int AnoVeiculo { get; set; }
    public string? ModeloVeiculo { get; set; }
    public double Valor { get; set; }
    public string? TipoVeiculo { get; set; }   //Descrição do veículo = Carro ou moto
    public bool Ativo { get; set;}
    public StatusVeiculo Status {get; set;}
}
