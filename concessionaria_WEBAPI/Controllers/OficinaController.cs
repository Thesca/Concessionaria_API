using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Repositorios.Interfaces;
namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OficinaController : ControllerBase {

    private readonly IOficinaRepositorio _oficinaRepositorio;
    public OficinaController(IOficinaRepositorio oficinaRepositorio)
    {
        _oficinaRepositorio = oficinaRepositorio;
    }
    [HttpGet]
    [Route("ListarOficina")]
    public async Task<ActionResult<List<OficinaModel>>> ListarOficina(){
        List<OficinaModel> carros = await _oficinaRepositorio.ListarOficina();
        return Ok(carros);
    }   
    //TODO Buscar Por Placa

    [HttpPost]
    [Route("CadastrarUmCarro")]
    public async Task<ActionResult<OficinaModel>>CadatrarCarroNaOficina([FromBody]OficinaModel OficinaModel){
        OficinaModel carro = await _oficinaRepositorio.AdicionarUmCarro(OficinaModel);
        return Ok(carro);
    }
    /*
    Task<OficinaModel> AdicionarUmCarro(OficinaModel carro);
    Task<OficinaModel> Atualizar(OficinaModel carro, string placa);
    Task<bool> RemoverCarroDaOficina(string placa); */
    
}