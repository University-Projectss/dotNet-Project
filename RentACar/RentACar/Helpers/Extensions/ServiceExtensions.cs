using RentACar.Helpers.JwtUtils;
using RentACar.Repositories.JobsRepository;
using RentACar.Repositories.UsersRepository;
using RentACar.Services.Jobs;
using RentACar.Services.Users;

namespace RentACar.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJobRepository, JobRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IJobsService, JobsService>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();

            return services;
        }
    }
}
