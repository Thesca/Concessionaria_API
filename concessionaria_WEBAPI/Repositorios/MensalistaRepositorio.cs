using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Repositorios{
    public class MensalistaRepositorio : IMensalistaRepositorio{
        private readonly ConcessionariaDBContext _dbContext;
        public MensalistaRepositorio(ConcessionariaDBContext concessionariaDBContext){
            _dbContext = concessionariaDBContext;
        }
        public async Task<MensalistaModel> BuscarPorCpf(int cpfMensalista)
        {
            var mensalista = _dbContext.Mensalista.FirstOrDefault(x => x.CpfMensalista == cpfMensalista);
            if(mensalista == null){
                throw new Exception($"Mensalista com CPF {mensalista} não foi encontrado no banco de dados.");
            }
            return mensalista;
        }
        public async Task<List<MensalistaModel>> ListarMensalistas()
        {
            return await _dbContext.Mensalista.ToListAsync();
        }
        public async Task<MensalistaModel> CadastrarUmMensalista(MensalistaModel mensalista)
        {
            await _dbContext.Mensalista.AddAsync(mensalista);
            await _dbContext.SaveChangesAsync();
            
            return mensalista;
        }
        public async Task<MensalistaModel> AtualizarMensalista(MensalistaModel mensalista, int cpfMensalista)
        {
            MensalistaModel mensalistaCpf = await BuscarPorCpf(cpfMensalista);

            if(mensalistaCpf == null) throw new Exception($"Mensalista com CPF {cpfMensalista} não foi encontrado no banco de dados.");
            mensalistaCpf.Status = mensalista.Status;

            _dbContext.Mensalista.Update(mensalistaCpf);
            await _dbContext.SaveChangesAsync();
            return mensalistaCpf;
        }
        public async Task<bool> RemoverMensalista(int cpfMensalista)
        {
            MensalistaModel mensalistaCpf = await BuscarPorCpf(cpfMensalista);

            if(mensalistaCpf == null) throw new Exception($"Mensalista com CPF {cpfMensalista} não foi encontrado no banco de dados.");
            _dbContext.Mensalista.Remove(mensalistaCpf);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}