using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;
    public class DocumentoModel{
        [Key]
        public string? PlacaDoc {get;set;}
        public bool CRLV {get;set;}
        public bool IPVA {get;set;}
        //FR Placa veiculo
    }