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
        IEnumerable<CourseFeedBack> GetAll();
        CourseFeedBack GetById(int id);
        IEnumerable<CourseFeedBack> GetByCourseId(int id);
        void Create(CourseFeedBack courseFeedBack);
        void Update(CourseFeedBack courseFeedBack);
        void Delete(int id);
        void Save();
    }
}
