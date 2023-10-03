using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseContentManagement.Data;
using CourseContentManagement.Data.Models;
using CourseContentManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseContentManagement.IntegrationEvents.Handlers
{
    public class CourseCreatedIntegrationEventHandler : IIntegrationEventHandler<CourseCreatedIntegrationEvent>
    {
        private readonly CourseContentDbContext dbContext;

        public CourseCreatedIntegrationEventHandler(CourseContentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(CourseCreatedIntegrationEvent @event)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == @event.Id).FirstOrDefault();
            if (course == null)
            {
                course = new Course { Id = @event.Id, UserId = @event.UserId, IsHidden = false, IsDeleted = false };

                await dbContext.Courses.AddAsync(course);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}