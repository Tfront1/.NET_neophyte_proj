using DataAccess.Repositories.CourseRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CourseRepo.Repos
{
    public class CourseFeedBackRepository : ICourseFeedBackRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseFeedBackRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<CourseFeedBack> GetAll()
        {
            return _context.CourseFeedBacks;
        }
        public CourseFeedBack GetById(int id)
        {
            return _context.CourseFeedBacks.Find(id);
        }
        public IEnumerable<CourseFeedBack> GetByCourseId(int id)
        {
            return _context.CourseFeedBacks.Where(x => x.CourseId == id);
        }
        public void Create(CourseFeedBack courseFeedBack)
        {
            _context.CourseFeedBacks.Add(courseFeedBack);
        }
        public void Update(CourseFeedBack courseFeedBack)
        {
            var courFg = _context.CourseFeedBacks.Find(courseFeedBack.Id);
            if (courFg != null)
            {
                courFg.Copy(courseFeedBack);
            }
        }
        public void Delete(int id)
        {
            var courFg = _context.CourseFeedBacks.Find(id);
            if (courFg != null)
            {
                _context.CourseFeedBacks.Remove(courFg);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
