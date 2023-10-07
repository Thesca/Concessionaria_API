using concessionaria_WEBAPI.Models;

public interface IPedidoRepositorio {

    Task<List<PedidoModel>> BuscarPedidos();
    Task<PedidoModel> BuscarPedidosPorId(int id);
    Task<PedidoModel> AdicionarPedido(PedidoModel pedido);
    Task<PedidoModel> AtualizarPedido(PedidoModel pedido, int id);
    Task<bool> FinalizarPedido(int id);

}