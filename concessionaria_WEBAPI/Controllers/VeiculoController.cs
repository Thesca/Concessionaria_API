/*using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;

namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class VeiculoController : ControllerBase
{
    private ConcessionariaDBContext _dbContext;

    public VeiculoController(ConcessionariaDBContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Veiculo veiculo)
    {
        _dbContext.Add(veiculo);
        _dbContext.SaveChanges();
        return Created("", veiculo);
    }
/*
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Veiculo>>> Listar()
    {
        if(_dbContext.Veiculos is null)
            return NotFound();
        return await _dbContext.Veiculos.ToListAsync();
    }
    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Veiculo>> Buscar([FromRoute] string placa)
    {
        if(_dbContext.Veiculos is null)
            return NotFound();
        var veiculo = await _dbContext.Veiculos.FindAsync(placa);
        if (veiculo is null)
            return NotFound();
        return veiculo;
    }

}
*/

