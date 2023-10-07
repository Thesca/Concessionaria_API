using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces;

public interface IMensalistaRepositorio{
    Task<List<MensalistaModel>> ListarMensalistas();
    Task<MensalistaModel> BuscarPorCpf(int cpfMensalista);
    Task<MensalistaModel> CadastrarUmMensalista(MensalistaModel mensalista);
    Task<MensalistaModel> AtualizarMensalista(MensalistaModel mensalista, int cpfMensalista);
    Task<bool> RemoverMensalista(int cpfMensalista); 
}