using Antonova.Core.Constants;
using Antonova.Core.Interfaces;
using Antonova.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Antonova.Core.Commands
{
    public class QuoteCommand : ITelegramCommand
    {

        /// <inheritdoc/>
        public string Name { get; } = "/quote";

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var httpHandler = new HttpHandler();
            var result = string.Empty;
            try
            {
                result = httpHandler.GetStringQuoteAsync(BotConstants.HOST).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                result = "Произошла ошибка с обработкой запроса";
            }
            await client.SendTextMessageAsync(chatId, result);
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }

}
