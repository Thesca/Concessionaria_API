using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces
{
    public interface IVeiculoRepositorio
    {
        Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo);
        Task<VeiculoModel> BuscarPorId(int id);
        Task<List<VeiculoModel>> BuscarTodosVeiculos();
        Task<List<VeiculoModel>> BuscarVeiculosAlugados();
        Task<List<VeiculoModel>> BuscarPorDescricao(string TipoVeiculo);
        Task<VeiculoModel> AtualizarVeiculo(VeiculoModel veiculo, int id);
        Task<bool> DeletarVeiculo(int id);
    }
}
