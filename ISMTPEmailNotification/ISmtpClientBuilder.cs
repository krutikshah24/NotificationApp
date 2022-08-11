using System.Net.Mail;

namespace EmailNotification.SMTP
{
    public interface ISmtpClientBuilder
    {
        SmtpClient GetSmtpClient();
    }
}