using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Repositorios
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly ConcessionariaDBContext _dbContext;
        public VeiculoRepositorio(ConcessionariaDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<VeiculoModel> AdicionarVeiculo(VeiculoModel veiculo)
        {
            veiculo.Status = VeiculoModel.StatusVeiculo.DISPONIVEL;
            veiculo.Ativo = true;
            await _dbContext.Veiculos.AddAsync(veiculo);
            await _dbContext.SaveChangesAsync();

            return veiculo;
        }

        public async Task<VeiculoModel> BuscarPorId(int id)
        {
            var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.IdVeiculo == id);

            if (veiculo is null)
            {
                throw new Exception($"Veículo para o ID: {id} não foi encontrado");
            }
            return veiculo;
        }

        public async Task<List<VeiculoModel>> BuscarVeiculosAlugados()
        {
            return await _dbContext.Veiculos.Where(x => x.Ativo == false).ToListAsync();
        }

        public async Task<List<VeiculoModel>> BuscarTodosVeiculos()
        {
            return await _dbContext.Veiculos.Where(x => x.Ativo == true).ToListAsync();
        }

        public async Task<List<VeiculoModel>> BuscarPorDescricao(string TipoVeiculo)
        {
            return await _dbContext.Veiculos.ToListAsync();
            //Busca por carro ou moto
        }
        public async Task<VeiculoModel> AtualizarVeiculo(VeiculoModel veiculo, int id)
        {
            VeiculoModel veiculoPorId = await BuscarPorId(id);

            if (veiculo is null)
            {
                throw new Exception($"Veículo para o ID: {id} não foi encontrado");
            }

            veiculoPorId.PlacaVeiculo = veiculo.PlacaVeiculo;
            veiculoPorId.AnoVeiculo = veiculo.AnoVeiculo;
            veiculoPorId.ModeloVeiculo = veiculo.ModeloVeiculo;
            veiculoPorId.Valor = veiculo.Valor;
            veiculoPorId.Status = veiculo.Status;
            veiculoPorId.TipoVeiculo = veiculo.TipoVeiculo;

            _dbContext.Veiculos.Update(veiculoPorId);
            await _dbContext.SaveChangesAsync();

            return veiculoPorId;
        }

        public async Task<bool> DeletarVeiculo(int id)
        {
            VeiculoModel veiculoPorId = await BuscarPorId(id);

            if (veiculoPorId is null)
            {
                throw new Exception($"Veículo para o ID: {id} não foi encontrado");
            }

            veiculoPorId.Ativo = false;

            _dbContext.Veiculos.Remove(veiculoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}