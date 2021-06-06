using System.Threading.Tasks;
using TaskTrackingSystem.BLL.Services.SmtpService;

namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    /// <summary>
    /// Interface for EmailService
    /// </summary>
    public interface IEmailService
    {
        Task SendEmailAsync(EmailInfo emailInfo);
    }
}