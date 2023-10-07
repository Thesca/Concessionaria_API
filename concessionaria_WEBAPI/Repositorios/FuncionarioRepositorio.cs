using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using System.IO.Compression;

namespace concessionaria_WEBAPI.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly ConcessionariaDBContext _dbContext;
        public FuncionarioRepositorio(ConcessionariaDBContext dBContext)
        {
            _dbContext = dBContext;         //pegar um contexto e buscar os funcionários
        }
        public async Task<FuncionarioModel> BuscarPorId(int id)
        {
            var funcionario = await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.IdFuncionario == id);
            if (funcionario is null)
            {
                throw new Exception($"Funcionário para o ID: {id} não foi encontrado");
            }
            return funcionario;
        }

        public async Task<List<FuncionarioModel>> BuscarTodosFuncionarios()
        {
            return await _dbContext.Funcionarios.ToListAsync();
        }

        public async Task<FuncionarioModel> AdicionarFuncionario(FuncionarioModel funcionario)
        {
           await _dbContext.Funcionarios.AddAsync(funcionario);
           await _dbContext.SaveChangesAsync();

           return funcionario;
        }

        public async Task<FuncionarioModel> AtualizarFuncionario(FuncionarioModel funcionario, int id)
        {
            FuncionarioModel funcionarioPorID = await BuscarPorId(id);

            if(funcionarioPorID is null)
            {
                throw new Exception($"Funcionário para o ID: {id} não foi encontrado");
            }

            funcionarioPorID.Cpf = funcionario.Cpf;
            funcionarioPorID.Nome = funcionario.Nome;
            funcionarioPorID.Cargo = funcionario.Cargo;
            funcionarioPorID.Salario = funcionario.Salario;
            funcionarioPorID.AnoContratatado = funcionario.AnoContratatado;

            _dbContext.Funcionarios.Update(funcionarioPorID);
            await _dbContext.SaveChangesAsync();

            return funcionarioPorID;
        }

        public async Task<bool> DeletarFuncionario(int id)
        {
            FuncionarioModel funcionarioPorID = await BuscarPorId(id);

            if(funcionarioPorID is null)
            {
                throw new Exception($"Funcionário para o ID: {id} não foi encontrado");
            }

            _dbContext.Funcionarios.Remove(funcionarioPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}