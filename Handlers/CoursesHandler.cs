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
            if (course == null || (course.IsHidden && (userId != null && course.UserId != userId)))
            {
                throw new NotFoundEntityException("course", courseId);
            }
        }
        public bool IsOwner(int courseId, int userId)
        {
            Course? course = repository.Get(courseId);
            return course.UserId == userId;
        }
    }
}