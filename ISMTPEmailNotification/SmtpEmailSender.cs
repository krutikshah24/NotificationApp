#region Imports

using EmailNotification.Email;
using EmailNotification.Smtp;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace EmailNotification.SMTP
{
    /// <summary>
    /// Used to send emails over SMTP.
    /// </summary>
    public class SmtpEmailSender : EmailSender
    {
        private readonly ISmtpClientBuilder _smtpClientBuilder;
        private readonly SmtpConfiguration _smtpConfiguration;
        public SmtpEmailSender(ISmtpClientBuilder smtpClientBuilder, SmtpConfiguration smtpConfiguration)
        {
            _smtpClientBuilder = smtpClientBuilder;
            _smtpConfiguration = smtpConfiguration;
        }

        /// <summary>
        /// Overridden Abstract method to send email in SmtpEmailSender Class.
        /// </summary>
        /// <param name="mail">Composed Mail Message to be sent</param>
        protected override async Task SendEmailAsync(MailMessage mail)
        {
            if (mail.From == null || string.IsNullOrEmpty(mail.From.Address))
            {
                mail.From = new MailAddress(
                    _smtpConfiguration.FromAddress,
                    _smtpConfiguration.FromDisplayName,
                    Encoding.UTF8
                );
            }

            using (var smtpClient = _smtpClientBuilder.GetSmtpClient())
            {
                await smtpClient.SendMailAsync(mail);
            }
        }
    }
}
