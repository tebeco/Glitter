using Discord.WebSocket;

using Freya.Ai;
using Freya.Providers.Discord.Events;

using Microsoft.Extensions.DependencyInjection;

namespace Freya.Providers.Discord
{
    public static class DiscordServiceExtensions
    {
        /// <summary>
        /// Adds the <see cref="DiscordChatbot"/> to the DI container.
        /// </summary>
        /// <param name="services">The service contract for adding services to the DI container.</param>
        /// <returns>The current <see cref="IServiceCollection"/> instance containing <see cref="DiscordChatbot"/> as a singleton service.</returns>
        public static ChatbotRegistrar AddDiscord(this ChatbotRegistrar registrar) =>
            registrar.AddChatbot<DiscordChatbot>()
                        .AddSettings<DiscordSettings>("discord")
                        .AddEventHandler<LogEventHandler>()
                        .AddEventHandler<LogEventHandler>()
                        .AddEventHandler<LoggedInEventHandler>()
                        .AddEventHandler<LoggedOutEventHandler>()
                        .AddEventHandler<ConnectedEventHandler>()
                        .AddEventHandler<DisconnectedEventHandler>()
                        .AddEventHandler<MessageReceivedEventHandler>()
                        .AddServices(services => services.AddSingleton<DiscordSocketClient>());
    }
}