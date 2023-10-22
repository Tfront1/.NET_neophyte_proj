
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.StudentRepo.Interfaces;
using DataAccess.Repositories.StudentRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using DataAccess.Repositories.TeacherRepo.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.WebApi.Services;
using Serilog;
using System.Reflection;
using WebApi.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.OpenApi.Models;

namespace neophyte_proj.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTStrings:jwtstr"]))
                    };
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                c =>
                {
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter bearer[space]token"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                                
                            },
                            new string[]{
                            }
                        }
                    });
                });

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog();

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<NeophyteApplicationContext>().Build();

            //Context injection
            var connectionString = configuration.GetConnectionString("neophyte");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            builder.Services.AddDbContext<NeophyteApplicationContext>(options =>
                options.UseMySql(connectionString, serverVersion));

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //Repo injection
            builder.AddApplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            try
            {
                Log.Information("Application started.");
                app.Run();
            }
            catch (Exception ex) {
                Log.Fatal(ex, "Application failed to start.");
            }

        }
    }
    public static class ServicesCl {
        public static void AddApplicationServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseFinancialInfoRepository, CourseFinancialInfoRepository>();
            services.AddTransient<ICourseFeedBackRepository, CourseFeedBackRepository>();
            services.AddTransient<ICourseBageRepository, CourseBageRepository>();

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentAccountInfoRepository, StudentAccountInfoRepository>();

            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITeacherFeedBackRepository, TeacherFeedBackRepository>();
            services.AddTransient<ITeacherAccountInfoRepository, TeacherAccountInfoRepository>();


            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ICourseFinancialInfoService, CourseFinancialInfoService>();
            services.AddTransient<ITeacherAccountInfoService, TeacherAccountInfoService>();
            services.AddTransient<IStudentAccountInfoService, StudentAccountInfoService>();
            services.AddTransient<ICourseBageService, CourseBageService>();
            services.AddTransient<ICourseFeedBackService, CourseFeedBackService>();
            services.AddTransient<ITeacherFeedBackService, TeacherFeedBackService>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }

    
}