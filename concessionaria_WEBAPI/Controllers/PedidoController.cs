using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Enum;
namespace concessionaria_WEBAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private ConcessionariaDBContext _dbContext;
    public PedidoController(ConcessionariaDBContext context)
    {
        _dbContext = context;
    }
}