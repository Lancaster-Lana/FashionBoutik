
using System.Threading.Tasks;

namespace FashionBoutik.Core
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
