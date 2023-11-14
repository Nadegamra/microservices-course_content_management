using CourseContentManagement.Data.Models;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Handlers
{
    public class CourseUpdatedIntegrationEventHandler : IIntegrationEventHandler<CourseUpdatedIntegrationEvent>
    {
        private readonly IRepository<Course> repository;

        public CourseUpdatedIntegrationEventHandler(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CourseUpdatedIntegrationEvent @event)
        {
            Course? original = repository.Get(@event.Id);
            if (original != null)
            {
                original.IsHidden = @event.IsHidden ?? original.IsHidden;
                original.IsDeleted = @event.IsDeleted ?? original.IsDeleted;
                repository.Update(original);
            }
        }
    }
}