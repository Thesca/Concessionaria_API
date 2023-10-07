using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Enum;
using concessionaria_WEBAPI.Repositorios;
namespace concessionaria_WEBAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public PedidoController(IPedidoRepositorio pedidoRepositorio){
        _pedidoRepositorio = pedidoRepositorio;
    }

    [HttpPost("/Pedido/Adicionar")]
    public async Task<ActionResult<PedidoModel>> AdicionarPedido(PedidoModel pedido)
    {
        PedidoModel pedidoNovo = await _pedidoRepositorio.AdicionarPedido(pedido);
        return Ok(pedidoNovo);
    }

    [HttpGet("/Pedido/Listar")]
    public async Task<ActionResult<List<PedidoModel>>> BuscarPedidos()
    {
        return await _pedidoRepositorio.BuscarPedidos();
    }

    [HttpGet("/Pedido/ListarPorId")]
    public async Task<ActionResult<PedidoModel>> BuscarPedidosPorId(int id)
    {
        return await _pedidoRepositorio.BuscarPedidosPorId(id);
    }

    [HttpPut("/Pedido/Atualiar")]
    public async Task<ActionResult<PedidoModel>> AtualizarPedido(PedidoModel pedido, int id)
    {
        PedidoModel pedidoAtualizado = await _pedidoRepositorio.AtualizarPedido(pedido, id);
        return Ok(pedidoAtualizado);
    }

    [HttpDelete("/Pedido/Finalizar")]
    public async Task<ActionResult<bool>> FinalizarPedido(int id)
    {
        bool finalizado = await _pedidoRepositorio.FinalizarPedido(id);
        if(!finalizado) throw new Exception($"Erro ao finalizar Pedido de ID: {id}");
        return Ok($"Pedido de ID: {id} Finalizado com Sucesso.");
    }   



}