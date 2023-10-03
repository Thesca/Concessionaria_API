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

    [HttpGet]
    [Route("ListarFuncionarios")]
    public async Task<ActionResult<List<FuncionarioModel>>> BuscarTodosFuncionarios()
    {
        List<FuncionarioModel> funcionarios = await _dbContext.BuscarTodosFuncionarios();
        return Ok(funcionarios);
    }

    [HttpGet]
    [Route("BuscarId")]
    public async Task<ActionResult<FuncionarioModel>> BuscarPorId(int IdFuncionario)
    {
        FuncionarioModel funcionario = await _dbContext.BuscarPorId(IdFuncionario);
        return Ok(funcionario);
    }

    [HttpPost]
    [Route("CadastrarFuncionario")]
    public async Task<ActionResult<FuncionarioModel>> Cadastrar([FromBody] FuncionarioModel funcionarioModel)
    {
        FuncionarioModel funcionario = await _dbContext.Adicionar(funcionarioModel);
        return Ok(funcionario);
    }

    [HttpPut]
    [Route("AlterarFuncionario")]
    public async Task<ActionResult<FuncionarioModel>> Atualizar([FromBody] FuncionarioModel funcionarioModel, int IdFuncionario)
    {
        funcionarioModel.IdFuncionario = IdFuncionario;
        FuncionarioModel funcionario = await _dbContext.Atualizar(funcionarioModel, IdFuncionario);
        return Ok(funcionario);
    }

    [HttpDelete]
    [Route("DeletarFuncionario")]
    public async Task<ActionResult<FuncionarioModel>> Deletar(int IdFuncionario)
    {
        bool deletado = await _dbContext.Apagar(IdFuncionario);
        return Ok(deletado);
    }
}
