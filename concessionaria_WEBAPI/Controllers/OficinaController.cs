using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    [Route("BuscarCarroPorID")]
    public async Task<ActionResult<OficinaModel>> BuscarPorIdNaOficina(int idCarroOficina){
        OficinaModel carro = await _oficinaRepositorio.BuscarPorId(idCarroOficina);
        return Ok(carro);
    }

    [HttpPost]
    [Route("CadastrarUmCarro")]
    public async Task<ActionResult<OficinaModel>>CadatrarCarroNaOficina([FromBody]OficinaModel oficinaModel){
        OficinaModel carro = await _oficinaRepositorio.AdicionarUmCarro(oficinaModel);
        return Ok(carro);
    }
    [HttpPut]
    [Route("AtualizarCarroNaOficina")]
    public async Task<ActionResult<OficinaModel>>AtualizarCarroNaOficina([FromBody]OficinaModel oficinaModel, int idCarroOficina){
        oficinaModel.IdCarroOficina = idCarroOficina;
        OficinaModel carro = await _oficinaRepositorio.Atualizar(oficinaModel, idCarroOficina);
        return Ok(carro);
    }
    [HttpDelete]
    [Route("RemoverCarroDaOficina")]
    public async Task<ActionResult<OficinaModel>> RemoverCarroDaOficina(int idCarroOficina){
        bool removido = await _oficinaRepositorio.RemoverCarroDaOficina(idCarroOficina);
        return Ok(removido);
    }
    
}