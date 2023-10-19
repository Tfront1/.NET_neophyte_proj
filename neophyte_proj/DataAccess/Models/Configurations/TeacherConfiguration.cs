using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.OwnsOne(s => s.TeacherGeneralInfo, generalInfo =>
                {
                    generalInfo.WithOwner();
                });

            builder
                .HasOne(s => s.TeacherAccountInfo)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey<TeacherAccountInfo>(t => t.TeacherId);

            builder
                .HasMany(t => t.TeacherFeedBacks)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey(t => t.TeacherId)
                    .HasPrincipalKey(t => t.Id);

            builder
                .HasMany(t => t.CourseTeacher)
                    .WithOne(t => t.Teacher)
                    .HasForeignKey(t => t.TeacherId)
                    .HasPrincipalKey(t => t.Id);
        }
    }
}
