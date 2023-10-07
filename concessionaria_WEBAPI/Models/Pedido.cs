using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using concessionaria_WEBAPI.Enum;

namespace concessionaria_WEBAPI.Models;

public class PedidoModel {
    [Key]
    public int Id {get; set;}
    public StatusPedido Status {get; set;}
    public string? Descricao {get;set;}
    public int? ClienteId {get;set;}
    public virtual ClienteModel? Cliente {get;set;}
    public int? MensalistaId {get;set;}
    public virtual MensalistaModel? Mensalista {get;set;}

    public int? FuncionarioId {get;set;}
    public virtual FuncionarioModel? Funcionario {get;set;}

    public  int? VeiculoId {get;set;}
    public virtual VeiculoModel? Veiculo {get;set;}

}