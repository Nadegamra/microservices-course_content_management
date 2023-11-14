using CourseContentManagement.Data.Models;

namespace CourseContentManagement.Data.Repositories
{
    public class InfoPagesRepository : IRepository<InfoPage>
    {

        public InfoPagesRepository(CourseContentDbContext dbContext) : base(dbContext)
        {

        }

        public override InfoPage? Get(int id)
        {
            return dbContext.InfoPages.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IEnumerable<InfoPage> GetAll()
        {
            return dbContext.InfoPages;
        }
    }
}