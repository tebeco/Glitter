using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Glittertind
{
    /// <summary>
    /// Represents a basic event handler.
    /// </summary>
    public abstract class EncapsulatedEventHandler : BackgroundService
    {
        /// <summary>
        /// The logger for the service the event is related to.
        /// </summary>
        public ILogger Logger { get; private set; }
        /// <summary>
        /// Creates a new <see cref="EncapsulatedEventHandler"/> instance.
        /// </summary>
        /// <param name="logger">The logger for the service the event is related to.</param>
        public EncapsulatedEventHandler(ILogger logger) =>
            Logger = logger;
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Logger.LogDebug("Listening for events.");
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
    }
}