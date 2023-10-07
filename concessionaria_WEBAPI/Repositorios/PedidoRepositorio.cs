using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using concessionaria_WEBAPI.Repositorios;
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

        // private readonly VeiculoRepositorio _veiculoRepositorio;

        // public PedidoRepositorio(VeiculoRepositorio veiculoRepositorio)
        // {
        //     _veiculoRepositorio = veiculoRepositorio;
        // }

        public async Task<List<PedidoModel>> BuscarPedidos()
        {
            return await _DbContext.Pedido
            .Include(x => x.Cliente)
            .Include(x => x.Mensalista)
            .Include(x => x.Funcionario)
            .Include(x => x.Veiculo)
            .ToListAsync();
        }

        public async Task<PedidoModel> BuscarPedidosPorId(int id)
        {
            PedidoModel pedidoPorId = await _DbContext.Pedido.Include(x => x.Cliente).Include(x => x.Mensalista).Include(x => x.Funcionario).Include(x => x.Veiculo).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Pedido de ID: {id} nao foi encotrado.");
            return pedidoPorId;
        }
        public async Task<PedidoModel> AdicionarPedido(PedidoModel pedido)
        {
            
            if(pedido.VeiculoId != null)
            {
                // Validando se o Veiculo ja foi vendido ou alugado
                pedido.Veiculo = await _DbContext.Veiculos.FirstOrDefaultAsync(x => x.IdVeiculo == pedido.VeiculoId);
                if(pedido.Veiculo.PedidoId != 0) throw new Exception($"Veiculo de Id: {pedido.Veiculo.IdVeiculo} nao esta Disponivel. Consulte os Veiculos Disponiveis.");
            }

            if(pedido.ClienteId != null)
            {
                // Adicionando pedido de compra de carros
                pedido.Cliente = await _DbContext.Cliente.FirstOrDefaultAsync(x => x.Id == pedido.ClienteId);
                VeiculoModel? veiculo = await _DbContext.Veiculos.FirstOrDefaultAsync(x => x.IdVeiculo == pedido.VeiculoId) ?? throw new Exception($"Veiculo de ID: {pedido.VeiculoId} nao encotrado");
                veiculo.Status = VeiculoModel.StatusVeiculo.VENDIDO;
            }   
            if(pedido.MensalistaId != null)
            {
                // Adicionando pedido de aluguel de carros
                pedido.Mensalista = await _DbContext.Mensalista.FirstOrDefaultAsync(x => x.CpfMensalista == pedido.MensalistaId);
                VeiculoModel? veiculo = await _DbContext.Veiculos.FirstOrDefaultAsync(x => x.IdVeiculo == pedido.VeiculoId) ?? throw new Exception($"Veiculo de ID: {pedido.VeiculoId} nao encotrado");
                veiculo.Status = VeiculoModel.StatusVeiculo.ALUGADO;
            }
            if(pedido.FuncionarioId != null)   pedido.Funcionario = await _DbContext.Funcionarios.FirstOrDefaultAsync(x => x.IdFuncionario == pedido.FuncionarioId);

            pedido.Status = Enum.StatusPedido.Andamento;
            await _DbContext.Pedido.AddAsync(pedido);
            await _DbContext.SaveChangesAsync();        
            await AtualizaPedidoId(pedido.VeiculoId, pedido.Id);
            return pedido;

        }

        public async Task<bool> AtualizaPedidoId(int? VeiculoId, int PedidoId)
        {
            VeiculoModel? veiculoNovo = await _DbContext.Veiculos.FirstOrDefaultAsync(x => x.IdVeiculo == VeiculoId);
            if(veiculoNovo == null) throw new Exception("");
            veiculoNovo.PedidoId = PedidoId;
            _DbContext.Veiculos.Update(veiculoNovo);
            _DbContext.SaveChanges();
            return true;
        }

        public async Task<PedidoModel> AtualizarPedido(PedidoModel pedido, int id)
        {
            PedidoModel pedidoPorId = await _DbContext.Pedido.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Pedido de ID: {id} nao foi encotrado.");
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