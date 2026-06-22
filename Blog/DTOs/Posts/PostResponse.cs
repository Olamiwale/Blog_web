using System.ComponentModel.DataAnnotations;

public class PostResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? AuthorUsername { get; set; }
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
}