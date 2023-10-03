using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        //Contratos dos Funcionarios
        Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario);
        Task<FuncionarioModel> BuscarPorId(int id);
        Task<List<FuncionarioModel>> BuscarTodosFuncionarios();
        Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id);
        Task<bool> Apagar(int id);
    }
}