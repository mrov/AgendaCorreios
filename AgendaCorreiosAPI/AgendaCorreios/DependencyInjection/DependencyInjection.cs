using Microsoft.EntityFrameworkCore;
using Repository;

namespace AgendaCorreios.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["ConnectionStrings:DefaultConnection"];

            // Configure EF Core with Oracle
            services.AddDbContext<MyDbContext>(options =>
                options.UseOracle(connectionString));

            // Add repository classes
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommitmentRepository, CommitmentRepository>();

            // Add services
            //services.AddScoped<IBudgetService, BudgetService>();

        }
    }
}
