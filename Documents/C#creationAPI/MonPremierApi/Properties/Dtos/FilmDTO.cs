using System.ComponentModel.DataAnnotations;

namespace Movie.Api.Dtos;

public record class FilmDTO
(
 [Required] int Id,
  [Required] string Titre,
  [Required] string Realisateur,
  [Required] DateOnly Sortie
 

);
    
