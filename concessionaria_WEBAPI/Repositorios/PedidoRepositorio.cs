using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace concessionaria_WEBAPI.Repositorios
{

    public class PedidoRepositorio : IPedidoRepositorio
    {

        private readonly ConcessionariaDBContext _DbContext;
        public PedidoRepositorio(ConcessionariaDBContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<List<PedidoModel>> BuscarPedidos()
        {
            return await _DbContext.Pedido.Where(x => x.Status != Enum.StatusPedido.Concluido).ToListAsync();
        }

        public async Task<List<PedidoModel>> BuscarPedidosFinalizados()
        {
            return await _DbContext.Pedido.Where(x => x.Status == Enum.StatusPedido.Concluido).ToListAsync();
        }

        public async Task<PedidoModel> BuscarPedidosPorId(int id)
        {
            PedidoModel pedidoPorId = await _DbContext.Pedido.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Pedido de ID: {id} nao foi encotrado.");
            return pedidoPorId;
        }
        public async Task<PedidoModel> AdicionarPedido(PedidoModel pedido)
        {
            pedido.Status = Enum.StatusPedido.Andamento;
            await _DbContext.Pedido.AddAsync(pedido);
            await _DbContext.SaveChangesAsync();
            return pedido;

        }

        public async Task<PedidoModel> AtualizarPedido(PedidoModel pedido, int id)
        {
            PedidoModel pedidoPorId = await _DbContext.Pedido.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Pedido de ID: {id} nao foi encotrado.");
            pedidoPorId.Valor = pedido.Valor;
            pedidoPorId.Descricao = pedido.Descricao;

            _DbContext.Pedido.Update(pedidoPorId);
            _DbContext.SaveChanges();

            return pedidoPorId;

        }
        public async Task<bool> FinalizarPedido(int id)
        {
            PedidoModel pedidoPorId = await _DbContext.Pedido.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Pedido de ID: {id} nao foi encotrado.");
            pedidoPorId.Status = Enum.StatusPedido.Concluido;

            _DbContext.Pedido.Update(pedidoPorId);
            _DbContext.SaveChanges();

            return true;

        }


    }

}