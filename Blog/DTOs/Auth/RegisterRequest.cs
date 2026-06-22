using System;

using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
    [Required] public string? Username {get; set;} = string.Empty;
    [Required] public string? Email {get; set;} = string.Empty;
    [Required] [MinLength(8)] public string Password {get; set;} = string.Empty;
}
