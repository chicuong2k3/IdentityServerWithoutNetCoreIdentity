namespace IdentityProvider.Services.Mail
{
    public class MailRequest
    {
        public string ReceiverEmail { get; set; }
        public string ReceiverName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
