using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotificationApp.Sms.Twilio.Extensions
{
    public static class TwilioServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a singleton service to the IServiceCollection
        /// </summary>
        /// <param name="services">IServiceCollection to add the services</param>
        private static void AddTwilioSmsService(this IServiceCollection services)
        {
            services.AddTransient<ITwilioClientBuilder, TwilioClientBuilder>();
            services.AddSingleton<ISmsSender, TwilioSmsSender>();
        }

        /// <summary>
        /// Adds a singleton service with its configuration to the IServiceCollection
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection to add the service</param>
        /// <param name="configuration">Configuration instance</param>
        public static void AddTwilioSmsConfig(this IServiceCollection serviceCollection, Action<TwilioConfig> configuration)
        {
            var config = new TwilioConfig();
            configuration.Invoke(config);
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddTwilioSmsService();
        }
    }
}
