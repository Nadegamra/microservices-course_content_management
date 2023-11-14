using CourseContentManagement.Data.Models;

namespace CourseContentManagement.Data.Repositories
{
    public class CoursesRepository : IRepository<Course>
    {
        public CoursesRepository(CourseContentDbContext dbContext) : base(dbContext)
        {

        }
        public override Course? Get(int id)
        {
            return dbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IEnumerable<Course> GetAll()
        {
            return dbContext.Courses;
        }
    }
}