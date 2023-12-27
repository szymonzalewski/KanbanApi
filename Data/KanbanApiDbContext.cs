using Microsoft.EntityFrameworkCore;


namespace KanbanApi;

public class KanabanApiDbContext : DbContext
{
    public KanabanApiDbContext(DbContextOptions<KanabanApiDbContext> options) : base(options)
    {
    }


    public DbSet<Models.Task> Tasks => Set<Models.Task>();
   



}


