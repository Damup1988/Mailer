using System.Threading.Tasks;
using Mailer.Models;

namespace Mailer.Services
{
    public interface ISender
    {
        Task<Email> SendAsync(string recipients, string subject, string body);
    }
}