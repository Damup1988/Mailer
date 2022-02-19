using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Models;

namespace Mailer.Repository
{
    public interface IEmailRepo
    {
        Task<IEnumerable<Email>> GetAllEmailsAsync();
        Task CreateEmailAsync(Email email);
    }
}