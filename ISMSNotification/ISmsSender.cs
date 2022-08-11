using System.Threading.Tasks;

namespace NotificationApp.Sms
{
    /// <summary>
    /// This service can be used for sending sms.
    /// </summary>
    public interface ISmsSender
    {
        /// <summary>
        /// Sends an sms.
        /// </summary>
        Task<bool> SendAsync(string toPhoneNumber, string text);
    }
}
