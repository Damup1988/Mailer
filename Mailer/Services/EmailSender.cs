using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Mailer.Services
{
    public class EmailSender : ISender
    {
        
        private static string SmtpHost { get; set; }
        private static int Port { get; set; }
        private static string From { get; set; }
        private static string Password { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            SmtpHost = configuration["SMTPsettings:SMTP"];
            Port = int.Parse(configuration["SMTPsettings:Port"]);
            From = configuration["SMTPsettings:From"];
            Password = configuration["SMTPsettings:Password"];
        }
        
        public async Task SendAsync(string recipients, string subject, string body)
        {
            var message = new MailMessage();
            var splitRecipients = recipients.Split(",");
            foreach (var recipient in splitRecipients) message.To.Add(recipient);

            message.From = new MailAddress(From);
            message.Subject = subject;
            message.Body = body;

            //var smtpServer = new SmtpClient();
            var hostname = System.Environment.GetEnvironmentVariable("COMPUTERNAME");

            var smtpClient = new SmtpClient();
            smtpClient.Host = SmtpHost;
            smtpClient.Port = Port;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(From, Password);

            await smtpClient.SendMailAsync(message);
            message.Dispose();
            smtpClient.Dispose();
        }
    }
}