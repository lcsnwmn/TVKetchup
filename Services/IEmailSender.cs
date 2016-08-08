using System.Threading.Tasks;

namespace TVKetchup.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
