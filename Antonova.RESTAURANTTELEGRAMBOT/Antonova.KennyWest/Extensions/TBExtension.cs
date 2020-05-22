using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Antonova.KennyWest.Extensions
{
    public static class TBExtension
    {
        /// <summary>
        /// Add TelegramBot client.
        /// </summary>
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var client = new TelegramBotClient(configuration["Token"]);
            var webHook = $"{configuration["Url"]}/api/message/update";
            client.SetWebhookAsync(webHook).Wait();

            serviceCollection.AddTransient<ITelegramBotClient>(x => client);

            return serviceCollection;

        }
    }
}
