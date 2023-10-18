using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neophyte_proj.DataAccess.Repositories.Repos
{
    public class CourseRepository : ICourseRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }
        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }
        public void Create(Course course)
        {
            _context.Courses.Add(course);
        }
        public void Update(Course course)
        {
            var cour = _context.Courses.Find(course.Id);
            if (cour != null)
            {
                cour.Copy(course);
            }
        }
        public void Delete(int id)
        {
            var cour = _context.Courses.Find(id);
            if (cour != null)
            {
                _context.Courses.Remove(cour);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
