using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;
    public class GaragemModel{
        [Key]
        public int IdVaga {get;set;}
        public string? PlacaVaga {get;set;}
        //FR Key Placa
    }