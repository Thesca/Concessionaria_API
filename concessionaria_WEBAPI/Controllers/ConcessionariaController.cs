using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ConcessionariaController : ControllerBase
{
    private ConcessionariaDBContext _dbContext;
    public ConcessionariaController(ConcessionariaDBContext context)
    {
        _dbContext = context;
    }
    [HttpPost]
    [Route("teste")]
    public async Task<IActionResult> Teste(Teste usuario){
        await _dbContext.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return Created("", usuario);
    }
    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<IEnumerable<Teste>>> Get(){
        return await _dbContext.Teste.ToListAsync();
    }
}
