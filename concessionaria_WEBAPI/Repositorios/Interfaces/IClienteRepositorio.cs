using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces
{

    public interface IClienteRepositorio 
    {

    Task<List<ClienteModel>> BuscarClientes();
    Task<List<ClienteModel>> BuscarClientesDesativados();
    Task<ClienteModel> BuscarClientePorId(int id);
    Task<ClienteModel> CadastraCliente(ClienteModel cliente);
    Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id);
    Task<bool> DesativarCliente(int id);

    }

}