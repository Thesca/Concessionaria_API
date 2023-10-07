using concessionaria_WEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using concessionaria_WEBAPI.Repositorios.Interfaces;
namespace concessionaria_WEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentoController : ControllerBase {

    private readonly IDocumentoRepositorio _documentoRepositorio;
    public DocumentoController(IDocumentoRepositorio documentoRepositorio)
    {
        _documentoRepositorio = documentoRepositorio;
    }
    [HttpGet]
    [Route("ListarDocumentacao")]
    public async Task<ActionResult<List<DocumentoModel>>> ListarDocumentacao(){
        List<DocumentoModel> docs = await _documentoRepositorio.ListarDocumentacao();
        return Ok(docs);
    }   
    [HttpGet]
    [Route("BuscarPorPlaca")]
    public async Task<ActionResult<DocumentoModel>> BuscarPorPlaca(string placaDoc){
        DocumentoModel docPorPlaca = await _documentoRepositorio.BuscarPorPlaca(placaDoc);
        return Ok(docPorPlaca);
    }
    [HttpPost]
    [Route("CadastrarDocumentacao")]
    public async Task<ActionResult<DocumentoModel>>CadastrarDocumentacao([FromBody]DocumentoModel documentoModel){
        DocumentoModel docNaPlaca = await _documentoRepositorio.CadastrarDocumentacao(documentoModel);
        return Ok(docNaPlaca);
    }
    [HttpPut]
    [Route("AtualizarDocumentacao")]
    public async Task<ActionResult<DocumentoModel>>AtualizarDocumentacao([FromBody]DocumentoModel documentoModel, string placaDoc){
        documentoModel.PlacaDoc = placaDoc;
        DocumentoModel docNaPlaca = await _documentoRepositorio.AtualizarDocumentacao(documentoModel, placaDoc);
        return Ok(docNaPlaca);
    }
    [HttpDelete]
    [Route("RemoverCarroDoc")]
    public async Task<ActionResult<DocumentoModel>> RemoverCarroDoc(string placaDoc){
        bool removido = await _documentoRepositorio.RemoverCarroDoc(placaDoc);
        return Ok(removido);
    }
    
}