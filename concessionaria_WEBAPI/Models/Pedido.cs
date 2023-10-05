using System.ComponentModel.DataAnnotations;
using concessionaria_WEBAPI.Enum;

namespace concessionaria_WEBAPI.Models;

public class PedidoModel {
    [Key]
    public int Id {get; set;}
    
    [Timestamp]
    public byte[]? DataHoraPedido { get; set; }

    public StatusPedido Status {get; set;}

    public double ValorCompra {get;set;}

}