using System.Text;
using Hospital.Database;
using Hospital.Models.Cadastro;
using Hospital.Repository.Agendamentos;
using Hospital.Repository.Agendamentos.Interfaces;
using Hospital.Repository.Atendimentos;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Service.Agendamentos;
using Hospital.Service.Agendamentos.Interfaces;
using Hospital.Service.Atendimentos;
using Hospital.Service.Atendimentos.Interfaces;
using Hospital.Service.Cadastros;
using Hospital.Service.Convenios;
using Hospital.Service.Convenios.Interfaces;
using Hospital.Service.Interfaces;
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
logger.Debug("Starting application");

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

// 1. DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DbSqlite"))
);

// 2. Identity
builder.Services.AddIdentity<Cadastro, IdentityRole<Guid>>()
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
            Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
        policy.RequireRole(Roles.Admin)
    );
    options.AddPolicy("StandardRights", policy =>
        policy.RequireRole(Roles.Admin, Roles.Medico, Roles.Paciente)
    );
    options.AddPolicy("OperationalRights", policy =>
        policy.RequireRole(Roles.Admin, Roles.Medico)
    );
});

// Repositorys
builder.Services.AddScoped(
    typeof(IAgendamentoRepository<,>),
    typeof(AgendamentoRepository<,>));
//   - Atendimentos
builder.Services.AddScoped<
    IConsultaRepository,
    ConsultaRepository>();

builder.Services.AddScoped(
    typeof(IAtendimentoRepository<>),
    typeof(AtendimentoRepository<>));
builder.Services.AddScoped<
    IExameRepository,
    ExameRepository>();

builder.Services.AddScoped<
    IRetornoRepository,
    RetornoRepository>();

//   - Agendamentos
builder.Services.AddScoped<
    IConsultaAgendamentoRepository,
    ConsultaAgendamentoRepository>();

builder.Services.AddScoped<
    IExameAgendamentoRepository,
    ExameAgendamentoRepository>();

builder.Services.AddScoped<
    IRetornoAgendamentoRepository,
    RetornoAgendamentoRepository>();

//  - Cadastros
builder.Services.AddScoped<
    IAuthenticationRepository,
    AuthenticationRepository>();

builder.Services.AddScoped<
    IPacienteRepository,
    PacienteRepository>();

builder.Services.AddScoped<
    IMedicoRepository,
    MedicoRepository>();

builder.Services.AddScoped<
    IConvenioRepository,
    ConvenioRepository>();

// Services
builder.Services.AddScoped(
    typeof(IAgendamentoService<,,>),
    typeof(AgendamentoService<,,>));
//   - Atendimentos
builder.Services.AddScoped<
    IConsultaService,
    ConsultaService>();

builder.Services.AddScoped(
    typeof(IAtendimentoService<,,,>),
    typeof(AtendimentoService<,,,>));
builder.Services.AddScoped<
    IExameService,
    ExameService>();

builder.Services.AddScoped<
    IRetornoService,
    RetornoService>();

//  - Agendamento
builder.Services.AddScoped<
    IConsultaAgendamentoService,
    ConsultaAgendamentoService>();

builder.Services.AddScoped<
    IExameAgendamentoService,
    ExameAgendamentoService>();

builder.Services.AddScoped<
    IRetornoAgendamentoService,
    RetornoAgendamentoService>();

//  - Cadastros
builder.Services.AddScoped<
    IAuthenticationService,
    AuthenticationService>();

builder.Services.AddScoped<
    IPacienteService,
    PacienteService>();

builder.Services.AddScoped<
    IMedicoService,
    MedicoService>();

builder.Services.AddScoped<
    IConvenioService,
    ConvenioService>();

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
