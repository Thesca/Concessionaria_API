using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class VeiculoController : ControllerBase
{
    private readonly IVeiculoRepositorio _dbContext;

    public VeiculoController(IVeiculoRepositorio veiculoRepositorio)
    {
        _dbContext = veiculoRepositorio;
    }

    [HttpPost]
    [Route("AdicionarVeiculo")]
    public async Task<ActionResult<VeiculoModel>> AdicionarVeiculo([FromBody] VeiculoModel veiculoModel)
    {
        VeiculoModel veiculo = await _dbContext.AdicionarVeiculo(veiculoModel);
        return Ok(veiculo);
    }

    [HttpGet]
    [Route("BuscarId")]
    public async Task<ActionResult<VeiculoModel>> BuscarPorId(int IdVeiculo)
    {
        VeiculoModel veiculo = await _dbContext.BuscarPorId(IdVeiculo);
        return Ok(veiculo);
    }

    [HttpGet]
    [Route("BuscarTodos")]
    public async Task<ActionResult<List<VeiculoModel>>> BuscarTodosVeiculos()
    {
        List<VeiculoModel> veiculos = await _dbContext.BuscarTodosVeiculos();
        return Ok(veiculos);
    }

    [HttpGet]
    [Route("BuscarAlugados")]
    public async Task<ActionResult<List<VeiculoModel>>> BuscarVeiculadosAlugados()
    {
        List<VeiculoModel> veiculos = await _dbContext.BuscarVeiculosAlugados();
        return Ok(veiculos);
    }

    [HttpGet]
    [Route("BuscarDescricao")]
    public async Task<ActionResult<List<VeiculoModel>>> BuscarPorDescricao(string TipoVeiculo)
    {
        List<VeiculoModel> veiculos = await _dbContext.BuscarPorDescricao(TipoVeiculo);
        return Ok(veiculos);
    }

    [HttpPut]
    [Route("AtualizarVeiculo")]
    public async Task<ActionResult<VeiculoModel>> AtualizarVeiculo([FromBody] VeiculoModel veiculoModel, int IdVeiculo)
    {
        veiculoModel.IdVeiculo = IdVeiculo;
        VeiculoModel veiculo = await _dbContext.AtualizarVeiculo(veiculoModel, IdVeiculo);
        return Ok(veiculo);
    }

    [HttpDelete]
    [Route("DeletarVeiculo")]
    public async Task<ActionResult<VeiculoModel>> DeletarVeiculo(int IdVeiculo)
    {
        bool deletado = await _dbContext.DeletarVeiculo(IdVeiculo);
        return Ok(deletado);
    }
}


