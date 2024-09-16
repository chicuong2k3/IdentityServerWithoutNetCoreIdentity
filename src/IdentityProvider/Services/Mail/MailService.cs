using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace IdentityProvider.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<MailService> _logger;

        public MailService(IOptions<MailSettings> mailSettingsOption, ILogger<MailService> logger)
        {
            _mailSettings = mailSettingsOption.Value;
            _logger = logger;
        }

        public async Task<bool> SendMailAsync(MailRequest mailRequest, string? htmlContent = null)
        {
            try
            {
                using (var emailMessage = new MimeMessage())
                {
                    var emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    var emailTo = new MailboxAddress(mailRequest.ReceiverName, mailRequest.ReceiverEmail);
                    emailMessage.To.Add(emailTo);

                    //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@gmail.com"));
                    //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@gmail.com"));

                    emailMessage.Subject = mailRequest.EmailSubject;
                    var bodyBuilder = new BodyBuilder();

                    if (!string.IsNullOrEmpty(htmlContent))
                    {
                        bodyBuilder.HtmlBody = htmlContent;
                    }
                    else
                    {
                        bodyBuilder.TextBody = mailRequest.EmailBody;
                    }

                    emailMessage.Body = bodyBuilder.ToMessageBody();
                    using (var mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return false;
            }
        }
    }
}
