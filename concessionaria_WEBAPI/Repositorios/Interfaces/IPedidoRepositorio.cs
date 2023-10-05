using concessionaria_WEBAPI.Models;

public interface IPedidoRepositorio {

    Task<List<PedidoModel>> BuscarPedidos();
    Task<PedidoModel> BuscarPedidosPorId(int id);
    Task<PedidoModel> AdicionarPedido(PedidoModel cliente);
    Task<PedidoModel> AtualizarPedido(PedidoModel cliente, int id);
    Task<PedidoModel> FinalizarPedido(PedidoModel cliente, int id);

}