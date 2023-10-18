
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.StudentRepo.Interfaces;
using DataAccess.Repositories.StudentRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using DataAccess.Repositories.TeacherRepo.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using neophyte_proj.DataAccess.Context;

namespace neophyte_proj.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<NeophyteApplicationContext>().Build();

            //Context injection
            var connectionString = configuration.GetConnectionString("neophyte");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            builder.Services.AddDbContext<NeophyteApplicationContext>(options => 
                options.UseMySql(connectionString, serverVersion));

            //Repo injection
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<ICourseFinancialInfoRepository, CourseFinancialInfoRepository>();
            builder.Services.AddTransient<ICourseFeedBackRepository, CourseFeedBackRepository>();
            builder.Services.AddTransient<ICourseBageRepository, CourseBageRepository>();

            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<IStudentAccountInfoRepository, StudentAccountInfoRepository>();

            builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
            builder.Services.AddTransient<ITeacherFeedBackRepository, TeacherFeedBackRepository>();
            builder.Services.AddTransient<ITeacherAccountInfoRepository, TeacherAccountInfoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}