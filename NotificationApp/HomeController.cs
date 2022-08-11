using EmailNotification.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationApp.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IEmailSender _iEmailSender;
        private readonly ISmsSender _ismsSender;

        public HomeController(IEmailSender emailSender, ISmsSender smsSender)
        {
            _iEmailSender = emailSender;
            _ismsSender = smsSender;
        }

        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmailToCustomer(EmailMessage emailMessage)
        {

            var message = new EmailMessage()
            {
                Subject = emailMessage.Subject ?? "Notification App Email!",
                Body = emailMessage.Body ?? "Welcome to Email Service!",
                FromAddress = emailMessage.FromAddress ?? "krutikshah24@gmail.com",
                FromName = emailMessage.FromName ?? "Notification App",
                ToAddress = emailMessage.ToAddress ?? "krutikshah24@gmail.com",
                ToName = emailMessage.ToName ?? "Krutik Shah",
                Bcc = emailMessage.FromAddress ?? "",
                Cc = emailMessage.FromAddress ?? "",
                IsHtml = emailMessage.IsHtml,
            };

            message.Body = $"{message.Body}";

            IEnumerable<string> cc = new List<string>() { emailMessage.Cc };

            // async
            await _iEmailSender.SendAsync(message.ToAddress, cc, message.Subject, message. Body, message.IsHtml);


            return Ok(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Route("send-sms")]
        public async Task<IActionResult> SendSmsToCustomer()
        {

            await _ismsSender.SendAsync("+911234567890", "Hi From Notification App");

            return Ok(StatusCodes.Status200OK);
        }
    }
}
