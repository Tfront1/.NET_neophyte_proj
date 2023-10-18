using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CourseRepo.Interfaces
{
    public interface ICourseFinancialInfoRepository
    {
        IEnumerable<CourseFinancialInfo> GetAll();
        CourseFinancialInfo GetById(int id);
        CourseFinancialInfo GetByCourseId(int id);
        void Create(CourseFinancialInfo courseFinancialInfo);
        void Update(CourseFinancialInfo courseFinancialInfo);
        void Delete(int id);
        void Save();
    }
}
