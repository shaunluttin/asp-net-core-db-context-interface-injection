using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) { }
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
