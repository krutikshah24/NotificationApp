namespace NotificationApp.Sms.Twilio
{
    public class TwilioConfig
    {
        /// <summary>
        /// Twilio account SID, authentication token and from phone number
        /// </summary>
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string FromPhoneNumber { get; set; }
    }
}
