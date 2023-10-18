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
    public class TeacherFeedBackRepository : ITeacherFeedBackRepository
    {
        private readonly NeophyteApplicationContext _context;
        public TeacherFeedBackRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public void Create(TeacherFeedBack teacherFeedBack)
        {
            _context.TeacherFeedBacks.Add(teacherFeedBack);
        }

        public void Delete(int id)
        {
            var techFb = _context.TeacherFeedBacks.Find(id);
            if (techFb != null) {
                _context.TeacherFeedBacks.Remove(techFb);
            }
        }

        public IEnumerable<TeacherFeedBack> GetAll()
        {
            return _context.TeacherFeedBacks;
        }

        public TeacherFeedBack GetById(int id)
        {
            return _context.TeacherFeedBacks.Find(id);
        }

        public IEnumerable<TeacherFeedBack> GetByTeacherId(int id)
        {
            return _context.TeacherFeedBacks.Where(x => x.TeacherId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TeacherFeedBack teacherFeedBack)
        {
            var techFb = _context.TeacherFeedBacks.Find(teacherFeedBack.Id);
            if (techFb != null) {
                techFb.Copy(teacherFeedBack);
            }
        }
    }
}
