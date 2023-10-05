using System.ComponentModel;

namespace concessionaria_WEBAPI.Enum 
{
    public enum StatusPedido {

        [Description("Pedido Concluido.")]
        Concluido = 1,

        [Description("Pedido em Andamento.")]
        Andamento = 2,
    }   
}
