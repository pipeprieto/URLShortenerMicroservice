using Microsoft.EntityFrameworkCore;
using URLShortenerMicroservice.Models;

namespace URLShortenerMicroservice.DB;

public class URLDbContext:DbContext{
    public URLDbContext(DbContextOptions<URLDbContext> options):base(options){}

    public DbSet<URLModel> uRLs =>Set<URLModel>();

}