using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
   public class Comment
{
    public int Id { get; set; }

    [Required] [MaxLength(500)] public string Content { get; set; } = string.Empty;

    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public int UserId { get; set; }
    public User? Author { get; set; }

    
    public Post? Post { get; set; }
}
}