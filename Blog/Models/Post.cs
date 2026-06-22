using System.ComponentModel.DataAnnotations;


namespace Blog.Models
{
    public class Post
{
    public int Id { get; set; }
    [Required] 
    [MaxLength(200)] 
    public string Title { get; set; } = string.Empty;
    
    [Required] 
    [MaxLength(2000)] 
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User? Author { get; set; }


    
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}
}

