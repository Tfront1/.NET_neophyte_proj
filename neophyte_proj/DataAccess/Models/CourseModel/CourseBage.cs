using DataAccess.Models.IntermediateModels;
using Microsoft.VisualBasic;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class CourseBage
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }

        //nto1
        public int CourseId { get; set; }
        public Course Course { get; set; }

        //nton
        public ICollection<BageStudent> BageStudent { get; set; }

        //copy
        public async Task Copy(CourseBage courseBage) {
            if (courseBage != null) {
                this.Name = courseBage.Name;
                this.Description = courseBage.Description;
                this.Rating = courseBage.Rating;
            }
        }
    }
}
