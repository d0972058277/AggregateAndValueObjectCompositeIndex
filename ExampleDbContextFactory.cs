using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AggregateAndValueObjectCompositeIndex
{
    public class ExampleDbContextFactory : IDesignTimeDbContextFactory<ExampleDbContext>
    {
        public ExampleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
            // docker run -itd --name mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root mysql:5.7
            var connectionString = "Server=127.0.0.1; Port=3306; User ID=root; Password=root; Database=Example;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new ExampleDbContext(optionsBuilder.Options);
        }
    }
}