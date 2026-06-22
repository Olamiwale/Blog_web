using System.ComponentModel.DataAnnotations;


public class CommentResponse
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string AuthorUsername { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}