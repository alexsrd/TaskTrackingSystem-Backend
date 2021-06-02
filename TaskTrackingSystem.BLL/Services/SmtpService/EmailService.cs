using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.BLL.Services.SmtpService
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _mailSettings;

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(EmailInfo emailInfo)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.EMail);
            email.To.Add(MailboxAddress.Parse(emailInfo.EmailTo));
            email.Subject = emailInfo.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = emailInfo.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.EMail, _mailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}