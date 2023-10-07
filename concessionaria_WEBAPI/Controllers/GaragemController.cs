using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using concessionaria_WEBAPI.Repositorios.Interfaces;
namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GaragemController : ControllerBase {

    private readonly IGaragemRepositorio _garagemRepositorio;
    public GaragemController(IGaragemRepositorio garagemRepositorio)
    {
        _garagemRepositorio = garagemRepositorio;
    }
    [HttpGet]
    [Route("ListarGaragem")]
    public async Task<ActionResult<List<GaragemModel>>> ListarGaragem(){
        List<GaragemModel> garagem = await _garagemRepositorio.ListarGaragem();
        return Ok(garagem);
    }   
    [HttpGet]
    [Route("BuscarPorId")]
    public async Task<ActionResult<MensalistaModel>> BuscarPorId(int idVaga){
        GaragemModel vaga = await _garagemRepositorio.BuscarPorId(idVaga);
        return Ok(vaga);
    }

    [HttpPost]
    [Route("CadastrarUmaVaga")]
    public async Task<ActionResult<GaragemModel>>CadastrarUmaVaga([FromBody]GaragemModel garagemModel){
        GaragemModel vaga = await _garagemRepositorio.CadastrarUmaVaga(garagemModel);
        return Ok(vaga);
    }
    [HttpPut]
    [Route("AtualizarCarroNaVaga")]
    public async Task<ActionResult<GaragemModel>>AtualizarCarroNaVaga([FromBody]GaragemModel garagemModel, int idVaga){
        garagemModel.IdVaga = idVaga;
        GaragemModel vagaAtt = await _garagemRepositorio.AtualizarVaga(garagemModel, idVaga);
        return Ok(vagaAtt);
    }
    [HttpDelete]
    [Route("RemoverCarroDaVaga")]
    public async Task<ActionResult<MensalistaModel>> RemoverCarroDaVaga(int idVaga){
        bool removido = await _garagemRepositorio.RemoverCarroDaVaga(idVaga);
        return Ok(removido);
    }
}