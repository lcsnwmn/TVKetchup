using System.Threading.Tasks;

namespace TVKetchup.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
