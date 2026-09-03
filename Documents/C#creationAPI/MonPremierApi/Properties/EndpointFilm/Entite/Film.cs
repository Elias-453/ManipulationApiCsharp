using Direction.Films.Entitee;

namespace Films.code.arbre;

public class FilmDetail
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int DirectorId { get; set; }
    public Director? Director { get; set; }
    public DateOnly ReleaseDate { get; set; }
}