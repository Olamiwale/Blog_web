using System.ComponentModel.DataAnnotations;


public class AddCommentRequest
{
    [Required][MaxLength(500)] public string Content { get; set; } = string.Empty;
    public int PostId { get; set; }
}