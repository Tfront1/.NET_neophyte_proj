using DataAccess.Models;
using DataAccess.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;

namespace neophyte_proj.DataAccess.Context
{
    public class NeophyteApplicationContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseFinancialInfo> CourseFinancialInfos { get; set; }
        public DbSet<CourseFeedBack> CourseFeedBacks { get; set; }
        public DbSet<CourseBage> CourseBags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAccountInfo> TeacherAccountInfos { get; set; }
        public DbSet<TeacherFeedBack> TeacherFeedBacks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAccountInfo> StudentAccountInfos { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public NeophyteApplicationContext(DbContextOptions<NeophyteApplicationContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<NeophyteApplicationContext>().Build();

            var connectionString = configuration.GetConnectionString("neophyte");

            var serverVersion = new MySqlServerVersion(new Version(8,0,34));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseStudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new BageStudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
    }
}
