using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmailNotification.Email
{
    public abstract class EmailSender : IEmailSender
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
        /// <returns>SendEmail Task Execution Status</returns>
        public virtual Task SendAsync(string to, IEnumerable<string> cc , string subject, string body, bool isBodyHtml = true,IEnumerable<IFormFile> attachments = null)
        {
            var message = new MailMessage()
            {
                To = { to },
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            if (cc != null && cc.Any<string>())
            {
                foreach (string str in cc.Where<string>((Func<string, bool>)(ccValue => !string.IsNullOrWhiteSpace(ccValue))))
                    message.CC.Add(str.Trim());
            }

            foreach (var file in attachments??new List<IFormFile>())
            {
                using (var fileStream = file.OpenReadStream())
                {
                    message.Attachments.Add(new Attachment(fileStream, file.FileName,file.ContentType));
                }
            }

            return SendAsync(message);
        }

        public virtual Task SendAsync(IEnumerable<string> to, IEnumerable<string> cc, string subject, string body, bool isBodyHtml = true, IEnumerable<IFormFile> attachments = null)
        {
            var message = new MailMessage()
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            foreach (var recipient in to)
            {
                message.To.Add(recipient);
            }

            foreach (var ccRecipient in cc)
            {
                message.CC.Add(ccRecipient);
            }

            foreach (var file in attachments ?? new List<IFormFile>())
            {
                using (var fileStream = file.OpenReadStream())
                {
                    message.Attachments.Add(new Attachment(fileStream, file.FileName, file.ContentType));
                }
            }

            return SendAsync(message);
        }

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
        /// <returns>SendEmail Task Execution Status</returns>
        public virtual Task SendAsync(string @from, string to, IEnumerable<string> cc, string subject, string body,bool isBodyHtml = true,IEnumerable<IFormFile> attachments=null)
        {
            var message = new MailMessage(from, to, subject, body)
            {
                IsBodyHtml = isBodyHtml
            };

            foreach (var ccRecipient in cc)
            {
                message.CC.Add(ccRecipient);
            }

            foreach (var file in attachments??new List<IFormFile>())
            {
                using (var fileStream = file.OpenReadStream())
                {
                    message.Attachments.Add(new Attachment(fileStream, file.FileName));
                }
            }

            return SendAsync(message);
        }

        public virtual Task SendAsync(string @from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body, bool isBodyHtml = true,IEnumerable<IFormFile> attachments = null)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            foreach (var recipient in to)
            {
                message.To.Add(recipient);
            }

            foreach (var ccRecipient in cc)
            {
                message.CC.Add(ccRecipient);
            }

            foreach (var file in attachments ?? new List<IFormFile>())
            {
                using (var fileStream = file.OpenReadStream())
                {
                    message.Attachments.Add(new Attachment(fileStream, file.FileName));
                }
            }
            
            return SendAsync(message);
        }

        /// <summary>
        /// Send an Email
        /// </summary>
        /// <param name="mail">Composed Mail Message to be sent</param>
        /// <returns>SendEmail Task Execution Status</returns>
        public virtual Task SendAsync(MailMessage mail)
        {
            NormalizeMail(mail);
            return SendEmailAsync(mail);
        }

        /// <summary>
        /// Normalizes given email.
        /// Fills <see cref="MailMessage.From"/> if it's not filled before.
        /// Sets encodings to UTF8 if they are not set before.
        /// </summary>
        /// <param name="mail">Mail to be normalized</param>
        private void NormalizeMail(MailMessage mail)
        {
            if (mail.HeadersEncoding == null)
            {
                mail.HeadersEncoding = Encoding.UTF8;
            }

            if (mail.SubjectEncoding == null)
            {
                mail.SubjectEncoding = Encoding.UTF8;
            }

            if (mail.BodyEncoding == null)
            {
                mail.BodyEncoding = Encoding.UTF8;
            }
        }

        /// <summary>
        /// Abstract method to send email in derived classes.
        /// </summary>
        /// <param name="mail">Composed Mail Message to be sent</param>
        protected abstract Task SendEmailAsync(MailMessage mail);
    }
}
