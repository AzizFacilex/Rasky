using System.Threading.Tasks;
namespace Rasky.API.Services {
    public interface ISmsSender {
        Task SendConfirmationSmsCodeAsync (string number);
        Task VerifyConfirmationSmsCodeAsync(string number, string code);
    }

}