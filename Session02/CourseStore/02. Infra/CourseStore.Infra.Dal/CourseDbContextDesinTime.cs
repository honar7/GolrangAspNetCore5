using Microsoft.EntityFrameworkCore.Design;

namespace CourseStore.Infra.Dal
{
    public class CourseDbContextDesinTime : IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            return DbContextProvider.GetSqlDbContext();
        }
    }

}
