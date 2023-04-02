using FluentResults;

namespace JetSetGo.Application.Email;

public interface IEmailService
{
    public Task<Result<EmailObject>> SendEmail(EmailObject emailObject);
}