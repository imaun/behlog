using System.Threading.Tasks;

namespace Behlog.Services.Contracts.Security {
    public interface IAppSmsService {

        Task SendMessageAsync(string number, string message);
    }
}
