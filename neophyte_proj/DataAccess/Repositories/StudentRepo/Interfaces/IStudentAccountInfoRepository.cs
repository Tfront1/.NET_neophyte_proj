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
        Task<IEnumerable<StudentAccountInfo>> GetByUsername(string username);
        Task<StudentAccountInfo> GetById(int id);
        Task<StudentAccountInfo> GetByStudentId(int id);
        Task<bool> Create(StudentAccountInfo studentAccountInfo);
        Task<bool> Update(StudentAccountInfo studentAccountInfo);
        Task<bool> Delete(int id);
        Task<bool> Save();
    }
}
