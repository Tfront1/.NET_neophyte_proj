using Microsoft.EntityFrameworkCore;
using neophyte_proj.Models.CourseModel;
using neophyte_proj.Models.IntermediateModels;
using neophyte_proj.Models.StudentModel;
using neophyte_proj.Models.TeacherModel;

namespace neophyte_proj.Context
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
            modelBuilder
                .Entity<CourseStudent>()
                .HasKey(t => new {t.CourseId,t.StudentId });
            modelBuilder
                .Entity<CourseTeacher>()
                .HasKey(t => new { t.CourseId, t.TeacherId });
            modelBuilder.Entity<Student>(student =>
            {
                student.OwnsOne(
                    t => t.StudentGeneralInfo,
                    generalInfo =>
                    {
                        generalInfo.WithOwner();
                    });

                student.HasOne(s => s.StudentAccountInfo)
                    .WithOne(t => t.Student)
                    .HasForeignKey<StudentAccountInfo>(t => t.StudentId);

                student
                    .HasMany(t => t.CourseBages)
                    .WithOne(t => t.Student)
                    .HasForeignKey(t => t.StudentId)
                    .HasPrincipalKey(t => t.Id);

                student
                    .HasMany(t => t.CourseStudent)
                    .WithOne(t => t.Student)
                    .HasForeignKey(t => t.StudentId)
                    .HasPrincipalKey(t => t.Id);
            });

            modelBuilder.Entity<Teacher>(teacher =>
            {
                teacher.OwnsOne(s => s.TeacherGeneralInfo, generalInfo =>
                {
                    generalInfo.WithOwner();
                });

                teacher
                    .HasOne(s => s.TeacherAccountInfo)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey<TeacherAccountInfo>(t => t.TeacherId);

                teacher
                    .HasMany(t => t.TeacherFeedBacks)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey(t => t.TeacherId)
                    .HasPrincipalKey(t => t.Id);

                teacher
                    .HasMany(t => t.CourseTeacher)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey(t => t.TeacherId)
                    .HasPrincipalKey(t => t.Id);
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.OwnsOne(s => s.CourseGeneralInfo, generalInfo =>
                {
                    generalInfo.WithOwner();
                });

                course
                    .HasOne(s => s.CourseFinancialInfo)
                    .WithOne(t => t.Course)
                    .HasForeignKey<CourseFinancialInfo>(t => t.CourseId);

                course
                    .HasMany(t => t.CourseFeedBacks)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

                course
                    .HasMany(t => t.CourseBages)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

                course
                    .HasMany(t => t.CourseTeacher)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

                course
                    .HasMany(t => t.CourseStudent)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

            });
        }
    }
}
