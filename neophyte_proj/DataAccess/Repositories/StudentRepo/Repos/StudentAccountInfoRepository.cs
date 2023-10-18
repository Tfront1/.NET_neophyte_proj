using DataAccess.Repositories.StudentRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.StudentRepo.Repos
{
    public class StudentAccountInfoRepository : IStudentAccountInfoRepository
    {
        private readonly NeophyteApplicationContext _context;
        public StudentAccountInfoRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public void Create(StudentAccountInfo studentAccountInfo)
        {
            _context.StudentAccountInfos.Add(studentAccountInfo);
        }

        public void Delete(int id)
        {
            var studAi = _context.StudentAccountInfos.Find(id);
            if (studAi != null) {
                _context.StudentAccountInfos.Remove(studAi);
            }
        }

        public IEnumerable<StudentAccountInfo> GetAll()
        {
            return _context.StudentAccountInfos;
        }

        public StudentAccountInfo GetById(int id)
        {
            return _context.StudentAccountInfos.Find(id);
        }

        public StudentAccountInfo GetByStudentId(int id)
        {
            return _context.StudentAccountInfos.FirstOrDefault(x=>x.StudentId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(StudentAccountInfo studentAccountInfo)
        {
            var studAi = _context.StudentAccountInfos.Find(studentAccountInfo.Id);
            if(studAi != null){
                studAi.Copy(studentAccountInfo);
            }
        }
    }
}
