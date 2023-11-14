using CourseContentManagement.Data.Models;

namespace CourseContentManagement.Data.Repositories
{
    public class SectionsRepository : IRepository<Section>
    {

        public SectionsRepository(CourseContentDbContext dbContext) : base(dbContext)
        {

        }

        public override Section? Get(int id)
        {
            return dbContext.Sections.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IEnumerable<Section> GetAll()
        {
            return dbContext.Sections;
        }
    }
}