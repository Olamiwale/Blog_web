using System.ComponentModel.DataAnnotations;
public class SendMessageRequest
{
    [Required] public string Content { get; set; } = string.Empty;
    public int ReceiverId { get; set; }
}

// MessageResponse.cs