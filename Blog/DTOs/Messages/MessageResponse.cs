using System.ComponentModel.DataAnnotations;
public class MessageResponse
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string SenderUsername { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}