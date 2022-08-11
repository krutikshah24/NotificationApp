using EmailNotification.Email;

namespace EmailNotification.Smtp
{
    public class SmtpConfiguration: EmailConfiguration
    {

        public string Server { get; set; }

        public int Port { get; set; }

        public string ProtocolType { get; set; }

        public string FromAddress { get; set; }

        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Host { get;  set; }
        public string Domain { get; set; }
        public string FromDisplayName { get; set; }
    }
}
