using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Events
{
    public class CourseCreatedIntegrationEvent : IntegrationEvent
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
    }
}