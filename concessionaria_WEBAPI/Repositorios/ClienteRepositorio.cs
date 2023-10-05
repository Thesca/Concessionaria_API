using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace concessionaria_WEBAPI.Repositorios
{

    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ConcessionariaDBContext _DbContext;
        public ClienteRepositorio(ConcessionariaDBContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<ClienteModel> CadastraCliente(ClienteModel cliente){
            cliente.Ativo = true;
            await _DbContext.Cliente.AddAsync(cliente);
            await _DbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id){
            ClienteModel clientePorId = await _DbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Clinete de ID: {id} nao encotrado.");
            clientePorId.Nome = cliente.Nome;
            clientePorId.Email = cliente.Email;
            clientePorId.Telefone = cliente.Telefone;

            _DbContext.Cliente.Update(clientePorId);
            _DbContext.SaveChanges();

            return cliente;
        }

        public async Task<bool> DesativarCliente(int id){
            ClienteModel clientePorId = await _DbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Clinete de ID: {id} nao encotrado.");
            clientePorId.Ativo = false;

            _DbContext.Cliente.Update(clientePorId);
            _DbContext.SaveChanges();
            return true;
        }

        public async Task<List<ClienteModel>> BuscarClientes(){
            return await _DbContext.Cliente.Where(x => x.Ativo == true).ToListAsync();
        }

        public async Task<List<ClienteModel>> BuscarClientesDesativados(){
            return await _DbContext.Cliente.Where(x => x.Ativo == false).ToListAsync();
        }

        public async Task<ClienteModel> BuscarClientePorId(int id){
            ClienteModel clientePorId = await _DbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Clinete de ID: {id} nao encotrado.");
            return clientePorId;
        }     
    }


}