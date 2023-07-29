using Microsoft.AspNetCore.Mvc;
using URLShortenerMicroservice.Models;
using URLShortenerMicroservice.Services;

namespace URLShortenerMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class URLController:ControllerBase{
    URLService service;
    private Random random = new Random();
    public URLController(URLService _service){
        service=_service;
    }

    [HttpPost]
    public IActionResult GenerateShortenedURL(URLModel url){
        string character = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcedefghijklmnopqrstuvwxyz0123456789";
        string shortenedUrl = new string(Enumerable.Repeat(character,8).Select(s=>s[random.Next(s.Length)]).ToArray());
        var newUrl = new URLModel {Urloriginal=$"{url.Urloriginal}", ShortID=shortenedUrl,Analytics=0};
        var createdUrl = service.Create(newUrl);
        return Ok(createdUrl!.ShortID);
    }

    [HttpGet("{id}")]
    public ActionResult GetReditectURL(string id){
        var finded = service.GetById(id);
        if(finded is null) throw new InvalidOperationException("No se ha podido encontrar la url ingresada");
        return Redirect($"{finded.Urloriginal}");
    }
}