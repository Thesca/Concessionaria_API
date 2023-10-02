using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;

    public class OficinaModel{
        [Key]
        public int IdCarroOficina {get;set;}
        public string? Procedimento {get;set;}
        //FR Placa veiculo
        //FR CPF func
    }