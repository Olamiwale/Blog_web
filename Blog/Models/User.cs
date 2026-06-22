using System.ComponentModel.DataAnnotations;


namespace Blog.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required][MaxLength(50)] public string Username { get; set; } = string.Empty;
        
        [Required][MaxLength(50)] public string? Email {get; set;} = string.Empty;


        public string? PasswordHash {get; set;}
        public string? Bio {get; set;}
        public string? ProfilePicture {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        

        public ICollection<Post> Posts {get; set;} = new List<Post>();
        public ICollection<Comment> Comments {get; set;} = new List<Comment>();

    }
}

