namespace JetSetGo.Infrastructure.Email;

public class EmailOptions
{
    public const string SendGridEmail = "EmailOptions";
    public string FromEmail { get; set; } = null!;
    public string FromName { get; set; } = null!;
}