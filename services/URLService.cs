using URLShortenerMicroservice.Models;
using URLShortenerMicroservice.DB;
using Microsoft.EntityFrameworkCore;

namespace URLShortenerMicroservice.Services;

public class URLService{
    private readonly URLDbContext _context;

    public URLService(URLDbContext context){
        _context = context;
    }

    public URLModel? Create(URLModel newUrl){
        _context.Add(newUrl);
        _context.SaveChanges();
        return newUrl;
    }

    public URLModel? GetById(string id){
        var urlFinded = _context.uRLs.Where(u=>u.ShortID == id).FirstOrDefault();
        if(urlFinded is null) throw new InvalidOperationException("La url no existe");
        return urlFinded;
        
    }
}