using CourseContentManagement.Data.Models;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.Exceptions;

namespace CourseContentManagement.Handlers
{
    public class CoursesHandler
    {
        private readonly IRepository<Course> repository;

        public CoursesHandler(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public void CheckCourseValidity(int courseId, int? userId = null)
        {
            Course? course = repository.Get(courseId);
            if (course == null)
            {
                throw new NotFoundEntityException("course", courseId);
            }
            if (userId != null && course.UserId != userId)
            {
                throw new NotEntityOwnerException("course", courseId, (int)userId);
            }
        }
    }
}