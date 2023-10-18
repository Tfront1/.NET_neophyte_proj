using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CourseRepo.Interfaces
{
    public interface ICourseBageRepository
    {
        IEnumerable<CourseBage> GetAll();
        CourseBage GetById(int id);
        IEnumerable<CourseBage> GetByCourseId(int id);
        void Create(CourseBage courseBage);
        void Update(CourseBage courseBage);
        void Delete(int id);
        void Save();
    }
}
