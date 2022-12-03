using RentACar.Helpers.JwtUtils;
using RentACar.Repositories.CarsRepository;
using RentACar.Repositories.JobsRepository;
using RentACar.Repositories.LocationsRepository;
using RentACar.Repositories.OfficeRepository;
using RentACar.Repositories.RentRepository;
using RentACar.Repositories.UsersRepository;
using RentACar.Services.Cars;
using RentACar.Services.Jobs;
using RentACar.Services.Locations;
using RentACar.Services.Offices;
using RentACar.Services.Rent;
using RentACar.Services.Users;

namespace RentACar.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IOfficeRepository, OfficeRepositorry>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IRentedRepository, RentedRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IJobsService, JobsService>();
            services.AddTransient<ILocationsService, LocationsService>();
            services.AddTransient<IOfficesService, OfficesService>();
            services.AddTransient<ICarsService, CarsService>();
            services.AddTransient<IRentService, RentService>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();

            return services;
        }
    }
}
