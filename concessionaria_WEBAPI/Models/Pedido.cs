using System.ComponentModel.DataAnnotations;
using concessionaria_WEBAPI.Enum;

namespace concessionaria_WEBAPI.Models;

public class PedidoModel {
    [Key]
    public int Id {get; set;}
    public StatusPedido Status {get; set;}
    public double Valor {get;set;}
    public string? Descricao {get;set;}
    public int? ClienteId {get;set;}
    public virtual ClienteModel? Cliente {get;set;}

}