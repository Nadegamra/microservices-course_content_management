using CourseContentManagement.Data.Models;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Handlers
{
    public class CourseCreatedIntegrationEventHandler : IIntegrationEventHandler<CourseCreatedIntegrationEvent>
    {
        private readonly IRepository<Course> repository;

        public CourseCreatedIntegrationEventHandler(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CourseCreatedIntegrationEvent @event)
        {
            Course? course = repository.Get(@event.Id);
            if (course == null)
            {
                course = new Course { Id = @event.Id, UserId = @event.UserId, IsHidden = true, IsDeleted = false };
                repository.Add(course);
            }
        }
    }
}