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
        IEnumerable<StudentAccountInfo> GetAll();
        StudentAccountInfo GetById(int id);
        StudentAccountInfo GetByStudentId(int id);
        void Create(StudentAccountInfo studentAccountInfo);
        void Update(StudentAccountInfo studentAccountInfo);
        void Delete(int id);
        void Save();
    }
}
