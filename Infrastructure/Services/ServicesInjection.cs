using Hospital.Application.Services;

namespace Hospital.Infrastructure.Services;
public static class ServicesInjection
{
    public static IServiceCollection InjectServices(
        this IServiceCollection services)
    {
        return services
            .AddScoped<IImageService, DiskImageService>()
            .AddScoped<IJwtTokenService, JwtTokenService>();
    }
}