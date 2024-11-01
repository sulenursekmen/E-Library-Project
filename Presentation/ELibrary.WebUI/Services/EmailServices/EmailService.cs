using MimeKit;
using MailKit.Net.Smtp;
namespace ELibrary.WebUI.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("E-Kütüphane Sayfa Yöneticisi", "sullenscode@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = subject;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("sullenscode@gmail.com", "...");
                await smtpClient.SendAsync(mimeMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
