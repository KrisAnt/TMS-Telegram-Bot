using Antonova.Core.Commands;
using Antonova.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace Antonova.Core.Services
{
    /// <inheritdoc cref="ICommandService"/>
    public class CommandService : ICommandService
    {
        private readonly IEnumerable<ITelegramCommand> _commands;

        /// <summary>
        /// Base constructor.
        /// </summary>
        public CommandService()
        {
            _commands = new List<ITelegramCommand>
            {
                 new StartCommand(),
                 new QuoteCommand()
            };
        }

        /// <inheritdoc/>
        public IEnumerable<ITelegramCommand> Get() => _commands;
    }
}
