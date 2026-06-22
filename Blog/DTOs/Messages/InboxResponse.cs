using System.ComponentModel.DataAnnotations;

    public class InboxResponse
    {
        public int OtherUserId { get; set; }
        public string OtherUsername { get; set; } = string.Empty;
        public string LastMessage { get; set; } = string.Empty;
        public DateTime LastMessageAt { get; set; }
    }
