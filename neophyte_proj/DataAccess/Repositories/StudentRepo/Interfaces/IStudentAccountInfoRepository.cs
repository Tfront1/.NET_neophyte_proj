using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.StudentRepo.Interfaces
{
    public interface IStudentAccountInfoRepository
    {
        Task<IEnumerable<StudentAccountInfo>> GetAll();
        Task<StudentAccountInfo> GetById(int id);
        Task<StudentAccountInfo> GetByStudentId(int id);
        Task Create(StudentAccountInfo studentAccountInfo);
        Task Update(StudentAccountInfo studentAccountInfo);
        Task Delete(int id);
        Task<bool> Save();
    }
}
