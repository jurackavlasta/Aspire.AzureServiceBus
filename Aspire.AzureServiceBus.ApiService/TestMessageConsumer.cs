using Aspire.AzureServiceBus.Messages;
using MassTransit;

namespace Aspire.AzureServiceBus.ApiService
{
    /// <summary>
    /// Consumer for test message
    /// </summary>
    public class TestMessageConsumer : IConsumer<TestMessage>
    {
        public Task Consume(ConsumeContext<TestMessage> context)
        {
            return Task.CompletedTask;
        }
    }
}
