using System;
using Twilio;
using Twilio.Exceptions;

namespace NotificationApp.Sms.Twilio
{
    public class TwilioClientBuilder : ITwilioClientBuilder
    {
        private readonly TwilioConfig _twilioConfig;
        public TwilioClientBuilder(TwilioConfig twilioConfig)
        {
            _twilioConfig = twilioConfig;
        }
        public void ConfigureTwilioClient()
        {
            if (string.IsNullOrEmpty(_twilioConfig.AccountSID))
                throw new ArgumentNullException($"Account SID can not be null");

            if (string.IsNullOrEmpty(_twilioConfig.AuthToken))
                throw new ArgumentNullException($"AuthToken can not be null");

            if (string.IsNullOrEmpty(_twilioConfig.FromPhoneNumber))
                throw new ArgumentNullException($"From Phone Number can not be null");

            try
            {
                // Initialize the TwilioClient.
                TwilioClient.Init(_twilioConfig.AccountSID, _twilioConfig.AuthToken);
            }
            catch (TwilioException ex)
            {
                // An exception occurred making the REST call
                throw new Exception(ex.Message);
            }
        }
    }
}
