using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace concessionaria_WEBAPI.Repositorios{
    public class OficinaRepositorio : IOficinaRepositorio{
        private readonly ConcessionariaDBContext _dbContext;
        public OficinaRepositorio(ConcessionariaDBContext concessionariaDBContext){
            _dbContext = concessionariaDBContext;
        }
        public async Task<OficinaModel> BuscarPorPlaca(string placa){
            throw new NotImplementedException();
            //return await _dbContext.Oficina.FirstOrDefault(x => x.Placa == placa); #AINDA NAO TEM A FR DA PLACA
        }

        public async Task<List<OficinaModel>> ListarOficina(){
            return await _dbContext.Oficina.ToListAsync();
        }
        public async Task<OficinaModel> AdicionarUmCarro(OficinaModel carro){
            await _dbContext.Oficina.AddAsync(carro);
            await _dbContext.SaveChangesAsync();
            
            return carro;
        }

        public async Task<OficinaModel> Atualizar(OficinaModel carro, string placa){
            OficinaModel carroPorPlaca = await BuscarPorPlaca(placa);

            if(carroPorPlaca == null) throw new Exception($"Carro com a placa {placa} não foi encontrado no banco de dados.");
            carroPorPlaca.Procedimento = carro.Procedimento;

            _dbContext.Oficina.Update(carroPorPlaca);
            await _dbContext.SaveChangesAsync();
            return carroPorPlaca;
        }



        public async Task<bool> RemoverCarroDaOficina(string placa){
            OficinaModel carroPorPlaca = await BuscarPorPlaca(placa);

            if(carroPorPlaca == null) throw new Exception($"Carro com a placa {placa} não foi encontrado no banco de dados.");
            _dbContext.Oficina.Remove(carroPorPlaca);
            await _dbContext.SaveChangesAsync();
            return true;
            
        }
    }
}