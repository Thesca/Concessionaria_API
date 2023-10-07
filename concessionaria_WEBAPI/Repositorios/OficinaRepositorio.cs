using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Repositorios
{
    public class OficinaRepositorio : IOficinaRepositorio{
        private readonly ConcessionariaDBContext _dbContext;
        public OficinaRepositorio(ConcessionariaDBContext concessionariaDBContext){
            _dbContext = concessionariaDBContext;
        }
        public async Task<OficinaModel> BuscarPorId(int idCarroOficina){
            var carroId =  _dbContext.Oficina.FirstOrDefault(x => x.IdCarroOficina == idCarroOficina);
            if(carroId == null){
                throw new Exception($"Carro com o ID {idCarroOficina} não foi encontrado no banco de dados.");
            }
            return carroId;
        }
        public async Task<List<OficinaModel>> ListarOficina(){
            return await _dbContext.Oficina.ToListAsync();
        }
        public async Task<OficinaModel> AdicionarUmCarro(OficinaModel carro){
            await _dbContext.Oficina.AddAsync(carro);
            await _dbContext.SaveChangesAsync();
            
            return carro;
        }
        public async Task<OficinaModel> Atualizar(OficinaModel carro, int idCarroOficina){
            OficinaModel carroPorId = await BuscarPorId(idCarroOficina);

            if(carroPorId == null) throw new Exception($"Carro com o ID {idCarroOficina} não foi encontrado no banco de dados.");
            carroPorId.Procedimento = carro.Procedimento;

            _dbContext.Oficina.Update(carroPorId);
            await _dbContext.SaveChangesAsync();
            return carroPorId;
        }
        public async Task<bool> RemoverCarroDaOficina(int idCarroOficina){
            OficinaModel carroPorId = await BuscarPorId(idCarroOficina);

            if(carroPorId == null) throw new Exception($"Carro com a placa {idCarroOficina} não foi encontrado no banco de dados.");
            _dbContext.Oficina.Remove(carroPorId);
            await _dbContext.SaveChangesAsync();
            return true;   
        }
    }
}