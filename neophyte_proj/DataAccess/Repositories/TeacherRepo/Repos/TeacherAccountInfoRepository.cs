using DataAccess.Repositories.TeacherRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.TeacherRepo.Repos
{
    public class TeacherAccountInfoRepository : ITeacherAccountInfoRepository
    {
        private readonly NeophyteApplicationContext _context;
        public TeacherAccountInfoRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public void Create(TeacherAccountInfo teacherAccountInfo)
        {
            _context.TeacherAccountInfos.Add(teacherAccountInfo);
        }

        public void Delete(int id)
        {
            var techAi = _context.TeacherAccountInfos.Find(id);
            if (techAi != null) {
                _context.TeacherAccountInfos.Remove(techAi);
            }
        }

        public IEnumerable<TeacherAccountInfo> GetAll()
        {
            return _context.TeacherAccountInfos;
        }

        public TeacherAccountInfo GetById(int id)
        {
            return _context.TeacherAccountInfos.Find(id);
        }

        public TeacherAccountInfo GetByTeacherId(int id)
        {
            return _context.TeacherAccountInfos.FirstOrDefault(x=>x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TeacherAccountInfo teacherAccountInfo)
        {
            var techAi = _context.TeacherAccountInfos.Find(teacherAccountInfo.Id);
            if (techAi != null)
            {
                techAi.Copy(teacherAccountInfo);
            }
        }
    }
}
