using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neophyte_proj.DataAccess.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Create(Course course);
        void Update(Course course);
        void Delete(int id);
        void Save();
    }
}
