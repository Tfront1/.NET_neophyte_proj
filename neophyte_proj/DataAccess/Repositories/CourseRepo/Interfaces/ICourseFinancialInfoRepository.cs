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
        Task<IEnumerable<CourseFinancialInfo>> GetAll();
        Task<CourseFinancialInfo> GetById(int id);
        Task<CourseFinancialInfo> GetByCourseId(int id);
        Task Create(CourseFinancialInfo courseFinancialInfo);
        Task Update(CourseFinancialInfo courseFinancialInfo);
        Task Delete(int id);
        Task<bool> Save();
    }
}
