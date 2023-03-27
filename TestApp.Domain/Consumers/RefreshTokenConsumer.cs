using MassTransit;

using Microsoft.Extensions.Logging;

using SharedCore.Model.Tokens;

namespace TestApp.Domain.Consumers
{
    public class RefreshTokenConsumer : IConsumer<RefreshTokenDto>
    {
        private readonly ILogger _logger;

        public RefreshTokenConsumer(ILogger<RefreshTokenConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<RefreshTokenDto> context)
        {
            
            _logger.LogWarning($"Refresh token was requested: {context.Message.Token}");

            return Task.CompletedTask;
        }
    }
}
