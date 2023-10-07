using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces;

public interface IGaragemRepositorio{
    Task<List<GaragemModel>> ListarGaragem();
    Task<GaragemModel> BuscarPorId(int idVaga);
    Task<GaragemModel> CadastrarUmaVaga(GaragemModel vagaGaragem);
    Task<GaragemModel> AtualizarVaga(GaragemModel vagaGaragem, int idVaga);
    Task<bool> RemoverCarroDaVaga(int idVaga); 
}