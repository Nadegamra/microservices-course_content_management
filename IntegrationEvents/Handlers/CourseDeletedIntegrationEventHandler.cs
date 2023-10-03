using CourseContentManagement.Data;
using CourseContentManagement.Data.Models;
using CourseContentManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Handlers
{
    public class CourseDeletedIntegrationEventHandler : IIntegrationEventHandler<CourseDeletedIntegrationEvent>
    {
        private readonly CourseContentDbContext dbContext;

        public CourseDeletedIntegrationEventHandler(CourseContentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(CourseDeletedIntegrationEvent @event)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == @event.Id).FirstOrDefault();
            if (course != null)
            {
                dbContext.Courses.Remove(course);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}