using Context.Data.Jeux;
using Microsoft.EntityFrameworkCore;
using Direction.Jeux.Entitee;
using Direction.Jeux.Dtos;
namespace Centralisation.Centre.Jeux;


public static class EndpointJeu
{
    public static RouteGroupBuilder CentralisationJeu(this WebApplication app)
    {

      
  using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContextJeu>();
    
    dbContext.Database.EnsureCreated();

  
    if (!dbContext.Studios.Any())
    {
        dbContext.Studios.AddRange(
            new Studio { Id = 1, Nom = "Epic Games", OriginePays = "USA", CreationStudio = 1991 },
            new Studio { Id = 2, Nom = "EA Sports", OriginePays = "Canada", CreationStudio = 1991 },
            new Studio { Id = 3, Nom = "CD Projekt Red", OriginePays = "Pologne", CreationStudio = 2002 },
            new Studio { Id = 4, Nom = "Rockstar Games", OriginePays = "USA", CreationStudio = 1998 },
            new Studio { Id = 5, Nom = "Mojang Studios", OriginePays = "Suède", CreationStudio = 2009 },
            new Studio { Id = 6, Nom = "Valve", OriginePays = "USA", CreationStudio = 1996 },
            new Studio { Id = 7, Nom = "Riot Games", OriginePays = "USA", CreationStudio = 2006 }
        );
        dbContext.SaveChanges();
    }

   
    if (!dbContext.Jeux.Any())
    {
        dbContext.Jeux.AddRange(
            new Jeu { Titre = "Fortnite", Genre = "Battle Royale", DatePublication = new DateOnly(2017, 7, 21), StudioId = 1 },
            new Jeu { Titre = "EA Sports FC 24", Genre = "Sport", DatePublication = new DateOnly(2023, 9, 29), StudioId = 2 },
            new Jeu { Titre = "The Witcher 3", Genre = "RPG", DatePublication = new DateOnly(2015, 5, 19), StudioId = 3 },
            new Jeu { Titre = "Cyberpunk 2077", Genre = "Action-RPG", DatePublication = new DateOnly(2020, 12, 10), StudioId = 3 },
            new Jeu { Titre = "Apex Legends", Genre = "FPS / Battle Royale", DatePublication = new DateOnly(2019, 2, 4), StudioId = 2 },
            new Jeu { Titre = "Grand Theft Auto V", Genre = "Action-Aventure", DatePublication = new DateOnly(2013, 9, 17), StudioId = 4 },
            new Jeu { Titre = "Minecraft", Genre = "Bac à sable", DatePublication = new DateOnly(2011, 11, 18), StudioId = 5 },
            new Jeu { Titre = "Counter-Strike 2", Genre = "FPS", DatePublication = new DateOnly(2023, 9, 27), StudioId = 6 },
            new Jeu { Titre = "Red Dead Redemption 2", Genre = "Action-Aventure", DatePublication = new DateOnly(2018, 10, 26), StudioId = 4 },
            new Jeu { Titre = "League of Legends", Genre = "MOBA", DatePublication = new DateOnly(2009, 10, 27), StudioId = 7 }
        );
        dbContext.SaveChanges();
    }
}
        var central = app.MapGroup("/Jeux")
                          .WithParameterValidation();

        // GET tous les jeux
        central.MapGet("/", async (ContextJeu dbContext) =>
            await dbContext.Jeux.ToListAsync());

        
        central.MapGet("/{id}", async (int id, ContextJeu dbContext) =>
        {
            var jeu = await dbContext.Jeux.FindAsync(id);

            return jeu is null
                ? Results.NotFound()
                : Results.Ok(jeu);
        })
        .WithName("GetJeu");

        // creation de jeux
        central.MapPost("/", async (CreationJeuDTO newJeu, ContextJeu dbContext) =>
        {
            if (string.IsNullOrEmpty(newJeu.Titre))
            {
                return Results.BadRequest("Le titre du jeu est obligatoire !");
            }

            Jeu nouveauJeu = new()
            {
                Titre = newJeu.Titre,
                StudioId = newJeu.StudioId,
                DatePublication = newJeu.DatePublication,
                Genre = newJeu.Genre
            };

            dbContext.Jeux.Add(nouveauJeu);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute("GetJeu", new { id = nouveauJeu.Id }, nouveauJeu);
        });

        // modifier un jeu
        central.MapPut("/{id}", async (int id, UpdateJeuDTO updateJeu, ContextJeu dbContext) =>
        {
            var jeu = await dbContext.Jeux.FindAsync(id);

            if (jeu is null)
            {
                return Results.NotFound();
            }

            jeu.Titre = updateJeu.Titre;
            jeu.StudioId = updateJeu.StudioId;
            jeu.DatePublication = updateJeu.DatePublication;
            jeu.Genre = updateJeu.Genre;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //  supprimer un jeu
        central.MapDelete("/{id}", async (int id, ContextJeu dbContext) =>
        {
            var deleted = await dbContext.Jeux
                .Where(j => j.Id == id)
                .ExecuteDeleteAsync();

            return deleted == 0
                ? Results.NotFound()
                : Results.NoContent();
        });

        return central;
    }
}
