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
    public class CourseUpdatedIntegrationEventHandler : IIntegrationEventHandler<CourseUpdatedIntegrationEvent>
    {
        private readonly CourseContentDbContext dbContext;

        public CourseUpdatedIntegrationEventHandler(CourseContentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(CourseUpdatedIntegrationEvent @event)
        {
            Course? original = dbContext.Courses.Where(x => x.Id == @event.Id).FirstOrDefault();
            if (original != null)
            {
                original.IsHidden = @event.IsHidden ?? original.IsHidden;
                original.IsDeleted = @event.IsDeleted ?? original.IsDeleted;
                dbContext.Courses.Update(original);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}