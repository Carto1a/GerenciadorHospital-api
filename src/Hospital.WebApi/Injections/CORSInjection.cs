namespace Hospital.WebApi.Injections;
public static class CORSInjection
{
    public static IServiceCollection InjectCORS(
        this IServiceCollection services)
    {
        // // 6. Add CORS policy
        // builder.Services.AddCors(options =>
        // {
        //     options.AddPolicy("AllowAngularDevClient",
        //         b =>
        //         {
        //             b
        //                 .WithOrigins("http://localhost:4200")
        //                 .AllowAnyHeader()
        //                 .AllowAnyMethod();
        //         });
        // });
        return services;
    }
}