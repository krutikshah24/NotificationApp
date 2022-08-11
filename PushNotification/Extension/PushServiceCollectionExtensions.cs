using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushNotification.Extension
{
   public static class PushServiceCollectionExtensions
    {
        /// Adds a transient service to the IServiceCollection
        /// </summary>
        /// <param name="service">IServiceCollection to add the service</param>
        private static void AddPushService(this IServiceCollection service)
        {
            service.AddSingleton(typeof(IPushSender), typeof(IPushSender));
        }

        /// <summary>
        /// Adds a singleton service to the IServiceCollection
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection to add the service</param>
        /// <param name="configuration">Configuration instance</param>
        public static void AddPushConfig(this IServiceCollection serviceCollection,
            Action<PushConfiguration> configuration)
        {
            var config = new PushConfiguration();
            configuration.Invoke(config);
            serviceCollection.AddSingleton(config);
            serviceCollection.AddPushService();
        }

    }
}
