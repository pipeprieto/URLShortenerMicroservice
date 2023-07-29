using URLShortenerMicroservice.Models;

namespace URLShortenerMicroservice.DB;

public static class DbInitializer{
    public static void Initialize(URLDbContext context){
        if(context.uRLs.Any()){
            return;
        }

        var shortenedUrl = new URLModel{Urloriginal = "https://www.youtube.com/",ShortID="X4Y9ua12",Analytics=0};
        context.uRLs.Add(shortenedUrl);
        context.SaveChanges();
    }
}

