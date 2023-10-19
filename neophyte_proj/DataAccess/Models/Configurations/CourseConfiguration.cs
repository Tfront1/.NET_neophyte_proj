using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.OwnsOne(s => s.CourseGeneralInfo, generalInfo =>
                {
                    generalInfo.WithOwner();
                });

            builder
                .HasOne(s => s.CourseFinancialInfo)
                    .WithOne(t => t.Course)
                    .HasForeignKey<CourseFinancialInfo>(t => t.CourseId);

            builder
                .HasMany(t => t.CourseFeedBacks)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

            builder
                .HasMany(t => t.CourseBages)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

            builder
                .HasMany(t => t.CourseTeacher)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);

            builder
                .HasMany(t => t.CourseStudent)
                    .WithOne(t => t.Course)
                    .HasForeignKey(t => t.CourseId)
                    .HasPrincipalKey(t => t.Id);
        }
    }
}
