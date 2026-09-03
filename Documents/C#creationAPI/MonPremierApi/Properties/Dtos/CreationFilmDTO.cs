namespace Film.Api.creation;
using System.ComponentModel.DataAnnotations;

public record class CreaionFilmDTO
(
 
 [Required] string Titre,
 [Required] string Realisateur,
 [Required] DateOnly Sortie
 

);
    