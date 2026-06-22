using System.ComponentModel.DataAnnotations;


namespace Blog.Models
{
   public class Message
{
    public int Id { get; set; }

    [Required] [MaxLength(1000)]  public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Who sent it and who receives it?
    public int SenderId { get; set; }
    public User? Sender { get; set; }

    public int ReceiverId { get; set; }
    public User? Receiver { get; set; }
}
}

