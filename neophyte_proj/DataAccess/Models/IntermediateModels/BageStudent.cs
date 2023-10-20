using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.IntermediateModels
{
    public class BageStudent
    {
        public int BageId { get; set; }
        public CourseBage CourseBage { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
