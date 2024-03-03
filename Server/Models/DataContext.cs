using Microsoft.EntityFrameworkCore;

namespace RickServer.Models;

public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DataContext() {}
    public DbSet<GetAllCharacters> GetAllCharacter  { get; set; }
    public DbSet<GetAllEpisodes> GetAllEpisode      { get; set; }
    public DbSet<Character> Characters  { get; set; }
    public DbSet<Episode> Episodes  { get; set; }
    public DbSet<Origin> Origins  { get; set; }
    public DbSet<Location> Locations  { get; set; }
    public DbSet<Info> Infos  { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data source=myDb.db");
    }

}