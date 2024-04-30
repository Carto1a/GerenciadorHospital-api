using System.Text;

using Hospital;
using Hospital.Consts;
using Hospital.Database;
using Hospital.Filter;
using Hospital.Helpers;
using Hospital.Models.Cadastro;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using NLog;
using NLog.Web;

// TODO: fazer o sistema louco? de log e id
// TODO: colocar o email que fez uma req importante no log

var basedir = AppDomain.CurrentDomain.BaseDirectory;
var logger = NLog.LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.Local.json");
FolderFileHelper.CheckConfigurations(configuration);
FolderFileHelper.CheckAndCreateFolders(configuration);

logger.Debug("Starting application");

var JWTSecret = configuration["JWT:Secret"];

// Logger Initialization
builder.Logging.ClearProviders();
builder.Host.UseNLog();

AppDomain.CurrentDomain
.UnhandledException += (sender, eventArgs) =>
{
    logger.Error(eventArgs.ExceptionObject.ToString(), "Stopped program because of exception");
    NLog.LogManager.Shutdown();
    Console.WriteLine(eventArgs.ExceptionObject.ToString());
};

// NOTE: Cade? Achei
Directory.CreateDirectory($"{basedir}\\logs");

// Exceptions Filter
builder.Services.AddMvc(options =>
    options.Filters.Add(typeof(ExceptionFilter)
));

// 1. DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DbSqlite"))
    /* options.UseSqlite(configuration.GetConnectionString("DbSqlServer")) */
);

// 2. Identity
builder.Services.AddIdentityCore<Cadastro>()
    .AddRoles<IdentityRole<Guid>>()
    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Admin>()
    .AddRoles<IdentityRole<Guid>>()
    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Paciente>()
    .AddRoles<IdentityRole<Guid>>()
    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Medico>()
    .AddRoles<IdentityRole<Guid>>()
    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 3. Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(JWTSecret!)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PoliciesConsts.Elevated, policy =>
        policy.RequireRole(Roles.Admin)
    );
    options.AddPolicy(PoliciesConsts.Standard, policy =>
        policy.RequireRole(Roles.Admin, Roles.Medico, Roles.Paciente)
    );
    options.AddPolicy(PoliciesConsts.Operational, policy =>
        policy.RequireRole(Roles.Admin, Roles.Medico)
    );
});

// 4. Dependency Injection
builder.Services.RegisterServices();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wedding Planner API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

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

var app = builder.Build();

// 4.1. Add seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedManager.Seed(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    });
}

// //7. Use CORS
// app.UseCors("AllowAngularDevClient");
app.UseHttpsRedirection();

// 8. Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();