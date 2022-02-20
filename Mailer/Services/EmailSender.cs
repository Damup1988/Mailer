using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Mailer.Models;
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
        
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>
        /// Return Email object to pass it to db
        /// </returns>
        public async Task<Email> SendAsync(string recipients, string subject, string body)
        {
            string result, errorMessage = "";
            
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

            //await smtpClient.SendMailAsync(message);
            try
            {
                await smtpClient.SendMailAsync(message);
                result = "OK";
            }
            catch (Exception e)
            {
                result = "ERROR";
                errorMessage = e.Message.ToString();
            }
            message.Dispose();
            smtpClient.Dispose();

            var email = new Email()
            {
                Id = Guid.NewGuid(),
                Body = body,
                ErrorMessage = errorMessage,
                Recipients = recipients,
                Result = result,
                Subject = subject,
                TimeStamp = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            };
            return email;
        }
    }
}