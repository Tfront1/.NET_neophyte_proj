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
    public class CourseRepository : ICourseRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAll()
        {
            return _context.Courses;
        }
        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task Create(Course course)
        {
            await _context.Courses.AddAsync(course);
        }
        public async Task Update(Course course)
        {
            var cour = await _context.Courses.FindAsync(course.Id);
            if (cour != null)
            {
                await cour.Copy(course);
            }
        }
        public async Task Delete(int id)
        {
            var cour = await _context.Courses.FindAsync(id);
            if (cour != null)
            {
                _context.Courses.Remove(cour);
            }
        }
        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
