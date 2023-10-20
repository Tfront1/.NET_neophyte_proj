using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsOne(
                    t => t.StudentGeneralInfo,
                    generalInfo =>
                    {
                        generalInfo.WithOwner();
                    });

            builder.HasOne(s => s.StudentAccountInfo)
                    .WithOne(t => t.Student)
                    .HasForeignKey<StudentAccountInfo>(t => t.StudentId);

            builder
                .HasMany(t => t.BageStudent)
                    .WithOne(t => t.Student)
                    .HasForeignKey(t => t.StudentId)
                    .HasPrincipalKey(t => t.Id);

            builder
                .HasMany(t => t.CourseStudent)
                    .WithOne(t => t.Student)
                    .HasForeignKey(t => t.StudentId)
                    .HasPrincipalKey(t => t.Id);
        }
    }
}
