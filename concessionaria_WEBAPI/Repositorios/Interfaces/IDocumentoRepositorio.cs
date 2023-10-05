using concessionaria_WEBAPI.Models;

namespace concessionaria_WEBAPI.Repositorios.Interfaces;

public interface IDocumentoRepositorio{
    Task<List<DocumentoModel>> ListarDocumentacao();
    Task<DocumentoModel> BuscarPorPlaca(string placaDoc);
    Task<DocumentoModel> CadastrarDocumentacao(DocumentoModel carroDoc);
    Task<DocumentoModel> AtualizarDocumentacao(DocumentoModel carroDoc, string placaDoc);
    Task<bool> RemoverCarroDoc(string placaDoc); 
}