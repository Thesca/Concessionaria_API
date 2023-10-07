using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        //Contratos dos Funcionarios
        Task<FuncionarioModel> AdicionarFuncionario(FuncionarioModel funcionario);
        Task<FuncionarioModel> BuscarPorId(int id);
        Task<List<FuncionarioModel>> BuscarTodosFuncionarios();
        Task<FuncionarioModel> AtualizarFuncionario(FuncionarioModel funcionario, int id);
        Task<bool> DeletarFuncionario(int id);
    }
}