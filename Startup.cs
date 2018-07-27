using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace temp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdbContext, dbContext>(options => options
                .UseSqlServer("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;"));

            services.AddTransient<IRepository, Repository>();
        }

        public void Configure() { }
    }

    public interface IdbContext { }

    public class dbContext : DbContext, IdbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
    }

    public class Repository : IRepository
    {
        private readonly IdbContext _context;

        public Repository(IdbContext context)
        {
            _context = context;
        }
    }

    public interface IRepository
    {
    }
}
