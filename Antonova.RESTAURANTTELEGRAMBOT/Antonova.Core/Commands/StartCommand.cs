﻿using Antonova.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Antonova.Core.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class StartCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = "/start";

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, $"Hello Kristina");
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type != MessageType.Text ? false : message.Text.Contains(Name);
    }
}
