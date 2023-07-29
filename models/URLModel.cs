using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace URLShortenerMicroservice.Models;

public class URLModel{
    public int Id {get; set;}
    [Required]
    public string Urloriginal { get; set;}

    public string? ShortID {get;set;}

    public int? Analytics {get;set;}


}