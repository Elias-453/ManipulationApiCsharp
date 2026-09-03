using Microsoft.EntityFrameworkCore;
using Direction.Jeux.Entitee;
using Microsoft.Net.Http.Headers;

namespace Context.Data.Jeux;

public class ContextJeu(DbContextOptions<ContextJeu> Options): DbContext(Options)
{
    
    
    public DbSet<Jeu> Jeux => Set<Jeu>();

    public DbSet <Studio> Studios => Set <Studio>();
}