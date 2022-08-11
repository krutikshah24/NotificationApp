#region Imports

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
#endregion

namespace EmailNotification.Email
{
    /// <summary>
    /// This service can be used simply sending emails.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Send an Email
        /// </summary>
        /// <param name="to">Recipient Email Address</param>
        /// <param name="cc">CC Recipient Email Address</param>
        /// <param name="subject">Subject of Email</param>
        /// <param name="body">Email Content (Body)</param>
        /// <param name="isBodyHtml">Is HTML Email Content</param>
        /// <param name="attachments">List of attachments</param>
        /// <returns>Task Execution Status</returns>
        Task SendAsync(string to, IEnumerable<string> cc, string subject, string body, bool isBodyHtml = true,
            IEnumerable<IFormFile> attachments = null);

        /// <summary>
        /// Send an Email to multiple Recipient
        /// </summary>
        /// <param name="to">Recipient Email Addresses</param>
        /// <param name="cc">CC Recipient Email Addresses</param>
        /// <param name="subject">Subject of Email</param>
        /// <param name="body">Email Content (Body)</param>
        /// <param name="isBodyHtml">Is HTML Email Content</param>
        /// <param name="attachments">List of attachments</param>
        /// <returns>Task Execution Status</returns>
        Task SendAsync(IEnumerable<string> to, IEnumerable<string> cc, string subject, string body, bool isBodyHtml = true,
            IEnumerable<IFormFile> attachments = null);

        /// <summary>
        /// Send an Email
        /// </summary>
        /// <param name="from">Sender Email Address</param>
        /// <param name="to">Recipient Email Address</param>
        /// <param name="cc">CC Recipient Email Address</param>
        /// <param name="subject">Subject of Email</param>
        /// <param name="body">Email Content (Body)</param>
        /// <param name="isBodyHtml">Is HTML Email Content</param>
        /// <param name="attachments">List of attachments</param>
        /// <returns>Task Execution Status</returns>
        Task SendAsync(string from, string to, IEnumerable<string> cc, string subject, string body, bool isBodyHtml = true, IEnumerable<IFormFile> attachments=null);

        /// <summary>
        /// Send an Email to multiple Recipient
        /// </summary>
        /// <param name="from">Sender Email Address</param>
        /// <param name="to">Recipient Email Addresses</param>
        /// <param name="cc">CC Recipient Email Addresses</param>
        /// <param name="subject">Subject of Email</param>
        /// <param name="body">Email Content (Body)</param>
        /// <param name="isBodyHtml">Is HTML Email Content</param>
        /// <param name="attachments">List of attachments</param>
        /// <returns>Task Execution Status</returns>
        Task SendAsync(string from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body, bool isBodyHtml = true, IEnumerable<IFormFile> attachments = null);

        /// <summary>
        /// Send an Email
        /// </summary>
        /// <param name="mail">Composed Mail Message</param>
        /// <returns>Task Execution Status</returns>
        Task SendAsync(MailMessage mail);
    }
}
