using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Repositorios{
    public class GaragemRepositorio : IGaragemRepositorio{
        private readonly ConcessionariaDBContext _dbContext;
        public GaragemRepositorio(ConcessionariaDBContext concessionariaDBContext){
            _dbContext = concessionariaDBContext;
        }
        public async Task<List<GaragemModel>> ListarGaragem(){
            return await _dbContext.Garagem.ToListAsync();
        }
        public async Task<GaragemModel> BuscarPorId(int idVaga){
            var vagaId =  _dbContext.Garagem.FirstOrDefault(x => x.IdVaga == idVaga);
            if(vagaId == null){
                throw new Exception($"Carro com o ID {idVaga} não foi encontrado no banco de dados.");
            }
            return vagaId;
        }
        public async Task<GaragemModel> CadastrarUmaVaga(GaragemModel vaga){
            await _dbContext.Garagem.AddAsync(vaga);
            await _dbContext.SaveChangesAsync();
            return vaga;
        }
        public async Task<GaragemModel> AtualizarVaga(GaragemModel vaga, int idVaga){
            GaragemModel vagaPorId = await BuscarPorId(idVaga);

            if(vagaPorId == null) throw new Exception($"Carro com o ID {idVaga} não foi encontrado no banco de dados.");
            vagaPorId.PlacaVaga = vaga.PlacaVaga;

            _dbContext.Garagem.Update(vagaPorId);
            await _dbContext.SaveChangesAsync();
            return vagaPorId;
        }
        public async Task<bool> RemoverCarroDaVaga(int idVaga){
            GaragemModel vagaPorId = await BuscarPorId(idVaga);

            if(vagaPorId == null) throw new Exception($"Carro com o ID {idVaga} não foi encontrado no banco de dados.");
            _dbContext.Garagem.Remove(vagaPorId);
            await _dbContext.SaveChangesAsync();
            return true;   
        }
    }
}