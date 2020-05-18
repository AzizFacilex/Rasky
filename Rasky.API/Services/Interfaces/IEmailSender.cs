using System.Threading.Tasks;
namespace Rasky.API.Services {
    public interface IEmailSender {
        Task SendConfirmationEmailAsync (string email, string subject, string htmlMessage);
        Task SendForgotPasswordEmailAsync (string email, string subject, string htmlMessage);

    }

}