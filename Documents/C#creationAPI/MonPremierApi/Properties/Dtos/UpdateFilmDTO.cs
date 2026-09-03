namespace Update.Film.DTO;
using System.ComponentModel.DataAnnotations;


public record class UpdateFilmDTO(
    
 [Required] string Titre,
 [Required] string Realisateur,
 [Required] DateOnly Sortie

);