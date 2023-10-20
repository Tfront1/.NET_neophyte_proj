using DataAccess.Models.IntermediateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Configurations
{
    internal class BageStudentConfiguration : IEntityTypeConfiguration<BageStudent>
    {
        public void Configure(EntityTypeBuilder<BageStudent> builder)
        {
            builder
                .HasKey(t => new { t.BageId, t.StudentId });
        }
    }
}
