using System.Threading.Tasks;
using Twilio.Types;
using static Twilio.Rest.Api.V2010.Account.MessageResource;

namespace NotificationApp.Sms.Twilio
{
    /// <summary>
    /// Used to send sms using Twilio.
    /// </summary>
    public class TwilioSmsSender : SmsSender
    {
        private readonly ITwilioClientBuilder _twilioClientBuilder;
        private readonly TwilioConfig _twilioConfig;

        #region Constructor
        public TwilioSmsSender(ITwilioClientBuilder twilioClientBuilder, TwilioConfig twilioConfig)
        {
            _twilioClientBuilder = twilioClientBuilder;
            _twilioConfig = twilioConfig;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toPhoneNumber">The phone number to which sms will be sent</param>
        /// <param name="text">Sms content to be sent</param>
        /// <returns></returns>
        protected override async Task<bool> SendSmsAsync(string toPhoneNumber, string text)
        {
            _twilioClientBuilder.ConfigureTwilioClient();

            // Send SMS.
            var message = await CreateAsync(
                to: new PhoneNumber(toPhoneNumber),
                from: new PhoneNumber(_twilioConfig.FromPhoneNumber),
                body: text);

            if (message.Status == StatusEnum.Sent)
            {
                return true;
            }

            return false;
        }
    }
}
