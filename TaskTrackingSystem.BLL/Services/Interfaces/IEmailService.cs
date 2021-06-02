using System.Threading.Tasks;
using TaskTrackingSystem.BLL.Services.SmtpService;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailInfo emailInfo);
    }
}