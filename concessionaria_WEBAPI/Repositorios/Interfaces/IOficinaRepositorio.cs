using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces;

public interface IOficinaRepositorio{
    Task<List<OficinaModel>> ListarOficina();
    Task<OficinaModel> BuscarPorPlaca(string placa);
    Task<OficinaModel> AdicionarUmCarro(OficinaModel carro);
    Task<OficinaModel> Atualizar(OficinaModel carro, string placa);
    Task<bool> RemoverCarroDaOficina(string placa); 
}