using FluentResults;
using JetSetGo.Application.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace JetSetGo.Infrastructure.Email;

public class EmailService: IEmailService
{
    private readonly EmailOptions _options;

    public EmailService(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task<Result<EmailObject>> SendEmail(EmailObject email)
    {
        DotNetEnv.Env.Load();
        DotNetEnv.Env.TraversePath().Load();
        var apiKey = Environment.GetEnvironmentVariable("EMAIL_API_KEY");
        if (!email.IsEmailAddressValid())
            return Result.Fail("Wrong email provided");
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage
        {
            From = new EmailAddress(_options.FromEmail, _options.FromName),
            Subject =email.Subject,
            PlainTextContent = email.PlainTextContent,
            HtmlContent = email.HtmlContent  
        };
        msg.AddTo(new EmailAddress(email.ToEmail));
        _ = await client.SendEmailAsync(msg);
        return email;
    }
}