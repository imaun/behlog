using System.Threading.Tasks;

namespace Behlog.Services.Contracts.Security {
    public interface IAppEmailService {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync<T>(string email, string subject, string viewNameOrPath, T model);
    }
}
