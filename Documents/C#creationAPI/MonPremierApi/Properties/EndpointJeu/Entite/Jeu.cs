namespace Direction.Jeux.Entitee;

public class Jeu
{
    public int Id { get; set; }
    public required string Titre { get; set; }
    public int StudioId { get; set; }
    public Studio? Studio { get; set; }
    public DateOnly DatePublication { get; set; }
    public required string Genre { get; set; }
}