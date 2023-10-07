using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios;
using concessionaria_WEBAPI.Repositorios.Interfaces;
using System.Text.RegularExpressions;
namespace concessionaria_WEBAPI.Controllers;


[ApiController]
[Route("/Cliente/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClienteController(IClienteRepositorio clienteRepositorio){
        _clienteRepositorio = clienteRepositorio;
    }

    [HttpPost("/Cliente/Cadastrar")]
    public async Task<ActionResult<ClienteModel>> CadastraCliente(ClienteModel cliente){
        ClienteModel clienteNovo = await _clienteRepositorio.CadastraCliente(cliente);
        return Ok(clienteNovo);
    }
 
    [HttpGet("/Cliente/Listar")]
    public async  Task<ActionResult<List<ClienteModel>>> BuscarClientes(){
        List<ClienteModel> clientes = await _clienteRepositorio.BuscarClientes();
        return Ok(clientes);
    }

    [HttpGet("/Cliente/Listar/Desativados")]
    public async  Task<ActionResult<List<ClienteModel>>> BuscarClientesDesativados(){
        List<ClienteModel> clientes = await _clienteRepositorio.BuscarClientesDesativados();
        return Ok(clientes);
    }

    [HttpGet("/Cliente/BuscarPorID")]
    public async  Task<ActionResult<ClienteModel>> BuscarClientePorId(int id){
        ClienteModel cliente = await _clienteRepositorio.BuscarClientePorId(id);
        return Ok(cliente);
    }

    [HttpPut("/Cliente/Atualizar")]
    public async Task<ActionResult<ClienteModel>> AtualizarCliente(ClienteModel cliente, int id)
    {
        ClienteModel clienteAtualizado = await _clienteRepositorio.AtualizarCliente(cliente, id);
        return Ok(clienteAtualizado);
    }

    [HttpDelete("/Cliente/Desativar")]
    
    public async Task<ActionResult<bool>> DesativarCliente(int id)
    {
        bool desativado = await _clienteRepositorio.DesativarCliente(id);
        if(!desativado) throw new Exception($"Erro ao desativar Cliente de ID: {id}");
        return Ok($"Cliente Desativado de ID: {id}.");
        
    }

}