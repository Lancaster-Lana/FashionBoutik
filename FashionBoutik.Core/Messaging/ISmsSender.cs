using System.Threading.Tasks;

namespace FashionBoutik.Core
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
