namespace Direction.Jeux.Dtos;

public record CreationJeuDTO
{
    public required string Titre { get; set; }
    public int StudioId { get; set; }
    public DateOnly DatePublication { get; set; }
    public required string Genre { get; set; }
}