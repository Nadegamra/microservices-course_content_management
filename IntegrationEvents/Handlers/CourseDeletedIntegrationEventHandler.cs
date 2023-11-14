using CourseContentManagement.Data.Models;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Handlers
{
    public class CourseDeletedIntegrationEventHandler : IIntegrationEventHandler<CourseDeletedIntegrationEvent>
    {
        private readonly IRepository<Course> repository;

        public CourseDeletedIntegrationEventHandler(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CourseDeletedIntegrationEvent @event)
        {
            Course? course = repository.Get(@event.Id);
            if (course != null)
            {
                repository.Delete(course);
            }
        }
    }
}