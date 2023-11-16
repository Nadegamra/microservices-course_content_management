namespace CourseContentManagement.Data.Repositories
{
    public abstract class IRepository<T> where T : class
    {
        protected readonly CourseContentDbContext dbContext;

        protected IRepository(CourseContentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public abstract T? Get(int id);
        public abstract IEnumerable<T> GetAll();
        public virtual T Add(T entity)
        {
            var res = dbContext.Add(entity);
            dbContext.SaveChanges();
            return (T)res.Entity;
        }
        public T Update(T entity)
        {
            var res = dbContext.Update(entity);
            dbContext.SaveChanges();
            return (T)res.Entity;
        }
        public T Delete(T entity)
        {
            var res = dbContext.Remove(entity);
            dbContext.SaveChanges();
            return (T)res.Entity;
        }
    }
}