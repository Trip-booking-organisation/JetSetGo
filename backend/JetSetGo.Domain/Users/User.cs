namespace JetSetGo.Domain.Users;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public String Email { get; set; } = null!;
    public String Password { get; set; } = null!;
    public String FirstName { get; set; } = null!;
    public String LastName { get; set; } = null!;
}