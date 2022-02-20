using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mailer.Services
{
    public class EmailSender : ISender
    {
        private static string smtpHost { get; set; } = "smtp.gmail.com";
        private static int port { get; set; } = 587;
        private static string from { get; set; } = "damup1988@gmail.com";
        
        public async Task SendAsync(string recipients, string subject, string body)
        {
            var message = new MailMessage();
            var splitRecipients = recipients.Split(",");
            foreach (var recipient in splitRecipients) message.To.Add(recipient);

            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = body;

            //var smtpServer = new SmtpClient();
            var hostname = System.Environment.GetEnvironmentVariable("COMPUTERNAME");

            var smtpClient = new SmtpClient();
            smtpClient.Host = smtpHost;
            smtpClient.Port = port;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("damup1988@gmail.com", "omuuvvlbvmhoplqn");

            await smtpClient.SendMailAsync(message);
            message.Dispose();
            smtpClient.Dispose();
        }
    }
}