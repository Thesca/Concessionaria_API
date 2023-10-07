using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;
    public class MensalistaModel
    {
        [Key]
        public int CpfMensalista {get;set;}
        public string? Status {get;set;}
        public string? DiaDaLocacao {get;set;}
    }
