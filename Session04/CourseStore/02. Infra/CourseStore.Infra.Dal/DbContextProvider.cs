using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infra.Dal
{
    public static class DbContextProvider
    {
        public static CourseDbContext GetSqlDbContext()
        {
            DbContextOptionsBuilder<CourseDbContext> optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer("Server=.,1733;Database=CourseDb; User Id=sa; Password=1qaz!QAZ");//.UseLazyLoadingProxies();
            return new CourseDbContext(optionsBuilder.Options);
        }
    }

}
