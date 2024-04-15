namespace YgoLocals.Core.Email
{
    using System.Net;
    using System.Net.Mail;
    using Microsoft.Extensions.Options;
    using YgoLocals.Infrastructure;

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<Config> appSettings)
        {
            _emailSettings = appSettings.Value.EmailSettings;
        }

        public async Task HandleForgotPasswordAsync(string mailTo, string callBackUrl)
        {
            string body = string.Format(Constants.Email.EmailForgodPasswordBody, callBackUrl);
            var message = GenerateMailMessage(mailTo, Constants.Email.EmailForgotPasswordSubject, body);

            await SendAsync(message);
        }

        public async Task HandleEmailChangeAsync(string mailTo, string callBackUrl)
        {
            string body = string.Format(Constants.Email.EmailChangeBody, callBackUrl);
            var message = GenerateMailMessage(mailTo, Constants.Email.EmailChangeSubject, body);

            await SendAsync(message);
        }

        public async Task HandleUserFormAsync(string mailTo)
        {
            // Set mail to handle use form reqeusts
            var message = GenerateMailMessage(mailTo, Constants.Email.EmailFormSubject, Constants.Email.EmailFormBody);

            await SendAsync(message);
        }

        private async Task SendAsync(MailMessage message)
        {
            using var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
            {
                Credentials = new NetworkCredential(_emailSettings.Mail, _emailSettings.Pass),
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            try
            {
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private MailMessage GenerateMailMessage(string mailTo, string subject, string body)
            => new(
                new MailAddress(_emailSettings.Mail), 
                new MailAddress(mailTo))
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
    }
}
