using Microsoft.EntityFrameworkCore;
using concessionaria_WEBAPI.Data;
using concessionaria_WEBAPI.Models;
using concessionaria_WEBAPI.Repositorios.Interfaces;

namespace concessionaria_WEBAPI.Repositorios{
    public class DocumentoRepositorio : IDocumentoRepositorio{
        private readonly ConcessionariaDBContext _dbContext;
        public DocumentoRepositorio(ConcessionariaDBContext concessionariaDBContext){
            _dbContext = concessionariaDBContext;
        }
        public async Task<List<DocumentoModel>> ListarDocumentacao(){
            return await _dbContext.Documento.ToListAsync();
        }
        public async Task<DocumentoModel> BuscarPorPlaca(string placaDoc){
            var docPorPlaca =  _dbContext.Documento.FirstOrDefault(x => x.PlacaDoc == placaDoc);
            if(docPorPlaca == null){
                throw new Exception($"Carro com a placa {placaDoc} não foi encontrado no banco de dados.");
            }
            return docPorPlaca;
        }
        public async Task<DocumentoModel> CadastrarDocumentacao(DocumentoModel docNaPlaca){
            await _dbContext.Documento.AddAsync(docNaPlaca);
            await _dbContext.SaveChangesAsync();
            
            return docNaPlaca;
        }
        public async Task<DocumentoModel> AtualizarDocumentacao(DocumentoModel docNaPlaca, string placaDoc){
            DocumentoModel docPorPlaca = await BuscarPorPlaca(placaDoc);

            if(docPorPlaca == null) throw new Exception($"Carro com a placa {placaDoc} não foi encontrado no banco de dados.");
            docPorPlaca.CRLV = docNaPlaca.CRLV;
            docPorPlaca.IPVA = docNaPlaca.IPVA;

            _dbContext.Documento.Update(docPorPlaca);
            await _dbContext.SaveChangesAsync();
            return docPorPlaca;
        }
        public async Task<bool> RemoverCarroDoc(string placaDoc){
            DocumentoModel docPorPlaca = await BuscarPorPlaca(placaDoc);

            if(docPorPlaca == null) throw new Exception($"Carro com a placa {placaDoc} não foi encontrado no banco de dados.");
            _dbContext.Documento.Remove(docPorPlaca);
            await _dbContext.SaveChangesAsync();
            return true;   
        }
    }
}