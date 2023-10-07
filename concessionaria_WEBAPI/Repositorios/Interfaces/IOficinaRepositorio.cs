using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces;

public interface IOficinaRepositorio{
    Task<List<OficinaModel>> ListarOficina();
    Task<OficinaModel> BuscarPorId(int idCarroOficina);
    Task<OficinaModel> AdicionarUmCarro(OficinaModel carro);
    Task<OficinaModel> Atualizar(OficinaModel carro, int idCarroOficina);
    Task<bool> RemoverCarroDaOficina(int idCarroOficina); 
}