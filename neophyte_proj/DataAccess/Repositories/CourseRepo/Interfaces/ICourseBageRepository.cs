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
        Task<IEnumerable<CourseBage>> GetAll();
        Task<CourseBage> GetById(int id);
        Task<IEnumerable<CourseBage>> GetByCourseId(int id);
        Task Create(CourseBage courseBage);
        Task Update(CourseBage courseBage);
        Task Delete(int id);
        Task<bool> Save();
    }
}
