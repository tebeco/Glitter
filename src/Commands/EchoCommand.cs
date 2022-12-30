﻿using System.Text;

using Discord.Commands;

using Freya.Core;

using Mauve.Runtime;

namespace Freya.Commands
{
    /// <summary>
    /// Represents a <see cref="Command"/> that echos input back to the user.
    /// </summary>
    [Alias("echo")]
    internal class EchoCommand : Command
    {
        private readonly string _input;
        /// <summary>
        /// Creates a new instance of <see cref="EchoCommand"/>.
        /// </summary>
        /// <param name="input">The input to be echoed back to the user.</param>
        /// <param name="logger"></param>
        public EchoCommand([FromBot] string input, ILogger<LogEntry> logger) :
            base("Echo", "Echoes the specified input back to the user.", logger) =>
            _input = input;
        /// <inheritdoc/>
        protected override async Task Work(CancellationToken cancellationToken)
        {
            byte[] data = Encoding.UTF8.GetBytes(_input);
            _ = new CommandResponse(data);
            //await invokingService.SendResponse(response, cancellationToken);
            await Task.CompletedTask; // TODO: remove.
        }
    }
}
