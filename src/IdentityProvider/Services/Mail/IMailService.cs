namespace IdentityProvider.Services.Mail
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(MailRequest mailRequest, string? htmlContent = null);
    }
}
