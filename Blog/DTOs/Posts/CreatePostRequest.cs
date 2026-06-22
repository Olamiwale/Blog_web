using System.ComponentModel.DataAnnotations;

public class CreatePostRequest
{
    [Required] [MaxLength(200)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Content { get; set; } = string.Empty;
}