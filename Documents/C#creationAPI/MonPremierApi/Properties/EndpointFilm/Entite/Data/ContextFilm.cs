using Microsoft.EntityFrameworkCore;
using Films.code.arbre;
using Direction.Films.Entitee;

namespace Context.Data.Films;

public class DataFilm(DbContextOptions<DataFilm> Options) : DbContext(Options)
{
    public DbSet<FilmDetail> Films => Set<FilmDetail>();
    public DbSet<Director> Directors => Set<Director>();

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Director>().HasData
    (
        new
        {
            Id = 1,
            Nom = "Christopher Nolan",
            Age = 56,
            nationalite = "Britannique"
        },
        new
        {
            Id = 2,
            Nom = "Quentin Tarantino",
            Age = 63,
            nationalite = "Américaine"
        },
        new
        {
            Id = 3,
            Nom = "Sofia Coppola",
            Age = 55,
            nationalite = "Américaine"
        }
    );
}
}