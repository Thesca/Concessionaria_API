using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SQLitePCL;
using System.ComponentModel.DataAnnotations;

namespace concessionaria_WEBAPI.Models;

public class Teste{
    [Key]
    public int Id {get; set;}
    public string? Nome {get; set;}
    public int Idade {get; set;}
}