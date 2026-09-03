using Update.Film.DTO;
using Movie.Api.Dtos;
using Film.Api.creation;
using Context.Data.Films;

namespace Centralisation.Film.Endpoint;

public static class Endpoint
{
    private static readonly List<FilmDTO> Film = new List<FilmDTO>()
    {

new FilmDTO(1, "Inception", "Christopher Nolan", new DateOnly(2010, 7, 16)),
new FilmDTO(2, "Parasite", "Bong Joon-ho", new DateOnly(2019, 5, 30)),
new FilmDTO(3, "Le Fabuleux Destin d'Amélie Poulain", "Jean-Pierre Jeunet", new DateOnly(2001, 4, 25)),
new FilmDTO(4, "Dune", "Denis Villeneuve", new DateOnly(2021, 9, 15)),
new FilmDTO(5, "The Batman", "Matt Reeves", new DateOnly(2022, 3, 4)),
new FilmDTO(6, "Interstellar", "Christopher Nolan", new DateOnly(2014, 11, 5)),
new FilmDTO(7, "Gladiator", "Ridley Scott", new DateOnly(2000, 6, 20)),
new FilmDTO(8, "The Dark Knight", "Christopher Nolan", new DateOnly(2008, 8, 13)),
new FilmDTO(9, "Pulp Fiction", "Quentin Tarantino", new DateOnly(1994, 10, 26)),
new FilmDTO(10, "Forrest Gump", "Robert Zemeckis", new DateOnly(1994, 10, 5)),
new FilmDTO(11, "Matrix", "Lana Wachowski, Lilly Wachowski", new DateOnly(1999, 6, 23)),
new FilmDTO(12, "Le Seigneur des Anneaux : La Communauté de l'Anneau", "Peter Jackson", new DateOnly(2001, 12, 19)),
new FilmDTO(13, "Le Seigneur des Anneaux : Les Deux Tours", "Peter Jackson", new DateOnly(2002, 12, 18)),
new FilmDTO(14, "Le Seigneur des Anneaux : Le Retour du Roi", "Peter Jackson", new DateOnly(2003, 12, 17)),
new FilmDTO(15, "Avatar", "James Cameron", new DateOnly(2009, 12, 16)),
new FilmDTO(16, "Titanic", "James Cameron", new DateOnly(1998, 01, 07)),
new FilmDTO(17, "Star Wars : Épisode IV - Un nouvel espoir", "George Lucas", new DateOnly(1977, 10, 19)),
new FilmDTO(18, "Star Wars : Épisode V - L'Empire contre-attaque", "Irvin Kershner", new DateOnly(1980, 08, 20)),
new FilmDTO(19, "Jurassic Park", "Steven Spielberg", new DateOnly(1993, 10, 20)),
new FilmDTO(20, "Interstellar", "Christopher Nolan", new DateOnly(2014, 11, 5)),
new FilmDTO(21, "Spider-Man: Into the Spider-Verse", "Bob Persichetti, Peter Ramsey, Rodney Rothman", new DateOnly(2018, 12, 12)),
new FilmDTO(22, "Whiplash", "Damien Chazelle", new DateOnly(2014, 12, 24)),
new FilmDTO(23, "La La Land", "Damien Chazelle", new DateOnly(2017, 1, 25)),
new FilmDTO(24, "Fight Club", "David Fincher", new DateOnly(1999, 11, 10)),
new FilmDTO(25, "Seven", "David Fincher", new DateOnly(1996, 01, 31)),
new FilmDTO(26, "Oppenheimer", "Christopher Nolan", new DateOnly(2023, 7, 19)),
new FilmDTO(27, "Barbie", "Greta Gerwig", new DateOnly(2023, 7, 19)),
new FilmDTO(28, "Spider-Man: Across the Spider-Verse", "Joaquim Dos Santos, Kemp Powers, Justin K. Thompson", new DateOnly(2023, 5, 31)),
new FilmDTO(29, "Intouchables", "Olivier Nakache, Éric Toledano", new DateOnly(2011, 11, 2)),
new FilmDTO(30, "Le Dîner de cons", "Francis Veber", new DateOnly(1998, 04, 15))
    
};
    public static RouteGroupBuilder CentralisationFilm(this WebApplication app)
    {
        var central = app.MapGroup("/Film")
                          .WithParameterValidation();

        // GET tous les films
        central.MapGet("/", () => Film);

        // GET un film
        central.MapGet("/{id}", (int id) =>
        {
            var film = Film.Find(f => f.Id == id);

            return film is null
                ? Results.NotFound()
                : Results.Ok(film);
        })
        .WithName("GetFilm");

        // POST pour créer un film
        central.MapPost("/", (CreaionFilmDTO newFilm, DataFilm dbContext) =>
        {
            if (string.IsNullOrEmpty(newFilm.Titre))
            {
                return Results.BadRequest(
                    "L'indication du titre du film est obligatoire !"
                );
            }

            FilmDTO nouveauFilm = new(
                Id: Film.Count + 1,
                Titre: newFilm.Titre,
                Realisateur: newFilm.Realisateur,
                Sortie: newFilm.Sortie
            );

            Film.Add(nouveauFilm);

            return Results.CreatedAtRoute(
                "GetFilm",
                new { id = nouveauFilm.Id },
                nouveauFilm
            );
        });

        // PUT pour modifier un film
        central.MapPut("/{id}", (int id, UpdateFilmDTO updatefilm) =>
        {
            var index = Film.FindIndex(f => f.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            Film[index] = new FilmDTO(
                id,
                updatefilm.Titre,
                updatefilm.Realisateur,
                updatefilm.Sortie
            );

            return Results.NoContent();
        });

        // DELETE supprimer un film
        central.MapDelete("/{id}", (int id) =>
        {
            var deleted = Film.RemoveAll(f => f.Id == id);

            if (deleted == 0)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });

        // GET rechercher un film par titre pour le lier à mon html css js 
        central.MapGet("/Recherche", (string? titre) =>
        {
            if (string.IsNullOrWhiteSpace(titre))
            {
                return Results.Ok(Film);
            }

            var resultats = Film.Where(f => f.Titre.Contains(titre, StringComparison.OrdinalIgnoreCase)).ToList();

            return Results.Ok(resultats);
        });

        return central;
    }
}