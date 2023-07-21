namespace Ecommerce.Core.Kafka;

public interface IIntegrationEventHandler
{
}

public interface IIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler
     where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}