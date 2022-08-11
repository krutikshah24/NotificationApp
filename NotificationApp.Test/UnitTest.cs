using EmailNotification.Email;
using EmailNotification.Smtp.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationApp.Test
{
    public class Tests
    {

        [Test]
        public void TestMail()
        {
            var services = new ServiceCollection();
            services.AddSmtpConfig(x =>
            {
                x.Domain = "smtp.gmail.com";
                x.Host = "smtp.gmail.com";
                x.FromAddress = "xxxx@gmail.com";
                x.FromDisplayName = "krutik Shah";
                x.Port = 587;
                x.EnableSsl = true;
                x.Password = "xxxx";
            });
            var dependency = Mock.Of<IEmailSender>();

            var message = new EmailMessage()
            {
                Subject = "Notification App Email!",
                Body = "Welcome to Email Service!",
                FromAddress = "krutikshah24@gmail.com",
                FromName = "Notification App",
                ToAddress = "krutikshah24@gmail.com",
                ToName = "Krutik Shah",
                Bcc = "",
                Cc = "",

            };

            message.Body = $"{message.Body}";

            IEnumerable<string> cc = new List<string>() { "a@gmail.com" };

            // async
            Task.Run(() => { dependency.SendAsync(message.ToAddress, cc, message.Subject, message.Body); }).GetAwaiter().GetResult();
            Assert.Pass();
        }
    }
}