using Microsoft.Extensions.DependencyInjection;
using NotificationApp.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsNotification.Extension
{
    public static class SmsServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a transient service to the IServiceCollection
        /// </summary>
        /// <param name="service">IServiceCollection to add the service</param>
        private static void AddEmailService(this IServiceCollection service)
        {
            service.AddSingleton(typeof(ISmsSender), typeof(SmsSender));
        }
    }
}
