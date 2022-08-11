using System;
using EmailNotification.SMTP;
using Microsoft.Extensions.DependencyInjection;
using EmailNotification.Email;

namespace EmailNotification.Smtp.Extensions
{
    /// <summary>
    /// Extension methods for adding services to an IServiceCollection
    /// </summary>
    public static class SmtpServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services to the IServiceCollection
        /// </summary>
        /// <param name="service">IServiceCollection to add the service</param>
        private static void AddEmailService(this IServiceCollection service)
        {
            service.AddSingleton<ISmtpClientBuilder, SmtpClientBuilder>();
            service.AddSingleton<IEmailSender, SmtpEmailSender>();
        }

        /// <summary>
        /// Adds a singleton service to the IServiceCollection
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection to add the service</param>
        /// <param name="configuration">Configuration instance</param>
        public static void AddSmtpConfig(this IServiceCollection serviceCollection,
            Action<SmtpConfiguration> configuration)
        {
             var config = new SmtpConfiguration();
            configuration.Invoke(config);
            serviceCollection.AddSingleton(config);
            serviceCollection.AddEmailService();
        }

    }
}
