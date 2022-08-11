using EmailNotification.SMTP;
using System.Net;
using System.Net.Mail;

namespace EmailNotification.Smtp
{
    public class SmtpClientBuilder : ISmtpClientBuilder
    {
        private readonly SmtpConfiguration _smtpConfiguration;
        public SmtpClientBuilder(SmtpConfiguration smtpConfiguration)
        {
            _smtpConfiguration = smtpConfiguration;
        }

        public SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(_smtpConfiguration.Server, _smtpConfiguration.Port);

            try
            {
                if (_smtpConfiguration.EnableSsl)
                {
                    smtpClient.EnableSsl = true;
                }

                if (_smtpConfiguration.UseDefaultCredentials)
                {
                    smtpClient.UseDefaultCredentials = true;
                }
                else
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Host = _smtpConfiguration.Host;
                    var userName = _smtpConfiguration.FromAddress;
                    if (!string.IsNullOrEmpty(userName))
                    {
                        var password = _smtpConfiguration.Password;
                        var domain = _smtpConfiguration.Domain;
                        smtpClient.Credentials = !string.IsNullOrEmpty(domain)
                            ? new NetworkCredential(userName, password, domain)
                            : new NetworkCredential(userName, password);
                    }
                }

                return smtpClient;
            }
            catch
            {
                smtpClient.Dispose();
                throw;
            }
        }

    }
}
