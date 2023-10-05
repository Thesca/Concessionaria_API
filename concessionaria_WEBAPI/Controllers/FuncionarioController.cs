using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Controllers;

[Route("[controller]")]
[ApiController]

//Aplicação dos CRUD

public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioRepositorio _dbContext;
    public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
    {
        _dbContext = funcionarioRepositorio;
    }

    [HttpPost]
    [Route("AdicionarFuncionario")]
    public async Task<ActionResult<FuncionarioModel>> AdicionarFuncionario([FromBody] FuncionarioModel funcionarioModel)
    {
        FuncionarioModel funcionario = await _dbContext.AdicionarFuncionario(funcionarioModel);
        return Ok(funcionario);
    }

    [HttpGet]
    [Route("BuscarId")]
    public async Task<ActionResult<FuncionarioModel>> BuscarPorId(int IdFuncionario)
    {
        FuncionarioModel funcionario = await _dbContext.BuscarPorId(IdFuncionario);
        return Ok(funcionario);
    }

    [HttpGet]
    [Route("ListarFuncionarios")]
    public async Task<ActionResult<List<FuncionarioModel>>> BuscarTodosFuncionarios()
    {
        List<FuncionarioModel> funcionarios = await _dbContext.BuscarTodosFuncionarios();
        return Ok(funcionarios);
    }

    [HttpPut]
    [Route("AlterarFuncionario")]
    public async Task<ActionResult<FuncionarioModel>> AtualizarFuncionario([FromBody] FuncionarioModel funcionarioModel, int IdFuncionario)
    {
        funcionarioModel.IdFuncionario = IdFuncionario;
        FuncionarioModel funcionario = await _dbContext.AtualizarFuncionario(funcionarioModel, IdFuncionario);
        return Ok(funcionario);
    }

    [HttpDelete]
    [Route("DeletarFuncionario")]
    public async Task<ActionResult<FuncionarioModel>> DeletarFuncionario(int IdFuncionario)
    {
        bool deletado = await _dbContext.DeletarFuncionario(IdFuncionario);
        return Ok(deletado);
    }
}
