using System;
using System.Threading.Tasks;

namespace NotificationApp.Sms
{
    public abstract class SmsSender : ISmsSender
    {
        public async Task<bool> SendAsync(string toPhoneNumber, string text)
        {
            if (string.IsNullOrEmpty(toPhoneNumber))
                throw new ArgumentNullException("Receiver's phone number can not be empty");
            if (text.Length>128)
                throw new ArgumentNullException("Message length should be less than 128 characters");
            return await SendSmsAsync(toPhoneNumber, text);
        }
        protected abstract Task<bool> SendSmsAsync(string toPhoneNumber, string text);
    }
}

