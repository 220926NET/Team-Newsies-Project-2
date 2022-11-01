using System.ComponentModel.DataAnnotations; 
public class LoginDto {

    [Required, MinLength(5), MaxLength(20)]
    public string UserName {get; set;} = string.Empty; 

    [Required, MinLength(10), MaxLength(20)]
    public string Password {get; set;} = string.Empty; 
}