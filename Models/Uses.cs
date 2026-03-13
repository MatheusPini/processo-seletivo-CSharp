namespace BlogMonolito.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; 
    
    public List<Post> Posts { get; set; } = new List<Post>();
}