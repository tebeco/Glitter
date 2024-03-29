using Discord.WebSocket;

using Microsoft.Extensions.Logging;

namespace Glitter.Discord.Events;

/// <summary>
/// Represents an <see cref="EncapsulatedEventHandler"/> for handling the LoggedIn event for a <see cref="DiscordSocketClient"/>.
/// </summary>
internal sealed class LoggedInEventHandler : EncapsulatedEventHandler
{
    private readonly DiscordSocketClient _client;
    /// <summary>
    /// Creates a new <see cref="LoggedInEventHandler"/> instance.
    /// </summary>
    /// <param name="client">The <see cref="DiscordSocketClient"/> to handle login events for.</param>
    /// <param name="logger">The logger for the <see cref="DiscordChatbot"/>.</param>
    public LoggedInEventHandler(DiscordSocketClient client, ILogger<DiscordChatbot> logger) :
        base(logger) =>
        _client = client;
    /// <inheritdoc/>
    protected override void Subscribe() =>
        _client.LoggedIn += HandleLogin;
    /// <inheritdoc/>
    protected override void Unsubscribe() =>
        _client.LoggedIn -= HandleLogin;
    private async Task HandleLogin()
    {
        Logger.LogDebug("Logged into Discord.");
        await Task.CompletedTask;
    }
}