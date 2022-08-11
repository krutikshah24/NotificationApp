using System;
using Microsoft.Extensions.DependencyInjection;
using EmailNotification.Email;

namespace EmailNotification.Extension
{
    /// <summary>
    /// Extension methods for adding services to an IServiceCollection
    /// </summary>
    public static class EmailServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a transient service to the IServiceCollection
        /// </summary>
        /// <param name="service">IServiceCollection to add the service</param>
        private static void AddEmailService(this IServiceCollection service)
        {
            service.AddSingleton(typeof(IEmailSender), typeof(IEmailSender));
        }

        /// <summary>
        /// Adds a singleton service to the IServiceCollection
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection to add the service</param>
        /// <param name="configuration">Configuration instance</param>
        public static void AddEmailConfig(this IServiceCollection serviceCollection,
            Action<EmailConfiguration> configuration)
        {
            var config = new EmailConfiguration();
            configuration.Invoke(config);
            serviceCollection.AddSingleton(config);
            serviceCollection.AddEmailService();
        }

    }
}
