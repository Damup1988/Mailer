using System.Threading.Tasks;

namespace Mailer.Services
{
    public interface ISender
    {
        Task SendAsync(string recipients, string subject, string body);
    }
}