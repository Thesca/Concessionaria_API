using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using concessionaria_WEBAPI.Repositorios.Interfaces;
namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MensalistaController : ControllerBase {

    private readonly IMensalistaRepositorio _mensalistaRepositorio;
    public MensalistaController(IMensalistaRepositorio mensalistaRepositorio)
    {
        _mensalistaRepositorio = mensalistaRepositorio;
    }
    [HttpGet]
    [Route("ListarMensalista")]
    public async Task<ActionResult<List<MensalistaModel>>> ListarMensalistas(){
        List<MensalistaModel> mensalistas = await _mensalistaRepositorio.ListarMensalistas();
        return Ok(mensalistas);
    }   
    [HttpGet]
    [Route("BuscarMensalistaPorCpf")]
    public async Task<ActionResult<MensalistaModel>> BuscarPorCpf(int cpfMensalista){
        MensalistaModel mensalista = await _mensalistaRepositorio.BuscarPorCpf(cpfMensalista);
        return Ok(mensalista);
    }

    [HttpPost]
    [Route("CadastrarUmMensalista")]
    public async Task<ActionResult<MensalistaModel>>CadastrarMensalista([FromBody]MensalistaModel mensalistaModel){
        MensalistaModel mensalista = await _mensalistaRepositorio.CadastrarUmMensalista(mensalistaModel);
        return Ok(mensalista);
    }
    [HttpPut]
    [Route("AtualizarMensalista")]
    public async Task<ActionResult<MensalistaModel>>AtualizarMensalista([FromBody]MensalistaModel mensalistaModel, int cpfMensalista){
        mensalistaModel.CpfMensalista = cpfMensalista;
        MensalistaModel mensalista = await _mensalistaRepositorio.AtualizarMensalista(mensalistaModel, cpfMensalista);
        return Ok(mensalista);
    }
    [HttpDelete]
    [Route("RemoverMensalista")]
    public async Task<ActionResult<MensalistaModel>> RemoverMensalista(int cpfMensalista){
        bool removido = await _mensalistaRepositorio.RemoverMensalista(cpfMensalista);
        return Ok(removido);
    }
    
}