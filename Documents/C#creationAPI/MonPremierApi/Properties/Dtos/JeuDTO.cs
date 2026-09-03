using Direction.Jeux.Entitee;

namespace Direction.Jeux.Dtos;

public record class JeuDTO
{
    
public int Id{get;set;}
 
public required string Titre{get;set;}

public Studio? Studio { get; set; }

public DateOnly DatePublication{get;set;}

public required string Genre{get;set;}

}