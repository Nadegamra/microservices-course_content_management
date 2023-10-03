using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Events
{
    public class CourseDeletedIntegrationEvent : IntegrationEvent
    {
        public required int Id { get; set; }
    }
}