using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CourseRepo.Interfaces
{
    public interface ICourseFeedBackRepository
    {
        Task<IEnumerable<CourseFeedBack>> GetAll();
        Task<CourseFeedBack> GetById(int id);
        Task<IEnumerable<CourseFeedBack>> GetByCourseId(int id);
        Task Create(CourseFeedBack courseFeedBack);
        Task Update(CourseFeedBack courseFeedBack);
        Task Delete(int id);
        Task<bool> Save();
    }
}
