using DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.StudentRepo.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<bool> Create(Student student);
        Task<bool> Update(Student student);
        Task<bool> Delete(int id);
        Task<bool> Save();
        Task<IEnumerable<Course>> GetCourses(int id);
        Task<bool> AddCourse(CourseStudent courseStudent);
        Task<IEnumerable<CourseBage>> GetBages(int id);
        Task<bool> AddBage(BageStudent bageStudent);
    }
}
