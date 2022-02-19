using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Models;

namespace Mailer.Repository
{
    public class MockEmailRepo : IEmailRepo
    {
        private readonly List<Email> _emails = new List<Email>
        {
            new Email
            {
                Id = Guid.NewGuid(),
                Recipients = new List<string>()
                {
                    "damup1988@gmail.com",
                    "damup1988@yandex.com",
                    "damup1988@outlook.com"
                },
                Body = "Good day! This is emailing service.",
                ErrorMessage = "",
                SendStatus = "OK"
            },
            new Email
            {
                Id = Guid.NewGuid(),
                Recipients = new List<string>()
                {
                    "damup1988@gmail.com"
                },
                Body = "Good day! This is emailing service.",
                ErrorMessage = "Can't reach SMTP server",
                SendStatus = "Failed"
            }
        };

        private IEnumerable<Email> GetAllEmail()
        {
            return _emails;
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            return await Task.Run(GetAllEmail);
        }

        public async Task CreateEmailAsync(Email email)
        {
            throw new System.NotImplementedException();
        }
    }
}