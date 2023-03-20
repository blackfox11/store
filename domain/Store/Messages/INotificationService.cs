using System.Threading.Tasks;

namespace Store.Messages
{
    public interface INotificationService
    {
        public void SendConfirmationCode(string cellPhone, int code);
        public Task SendConfirmationCodeAsync(string cellPhone, int code);
        public void StartProcess(Order order);
        public Task StartProcessAsync(Order order);
    }
}
