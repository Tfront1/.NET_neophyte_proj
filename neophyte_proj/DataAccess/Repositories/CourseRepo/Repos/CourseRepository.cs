using DataAccess.Repositories.CourseRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
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
        public async Task<bool> Create(Course course)
        {
            _ = course ?? throw new ArgumentNullException(nameof(course));
            try
            {
                await _context.Courses.AddAsync(course);
                return true;
            }
            catch 
            {
                return false;
            }
            
        }
        public async Task<bool> Update(Course course)
        {
            _ = course ?? throw new ArgumentNullException(nameof(course));
            var cour = await _context.Courses.FindAsync(course.Id);
            if (cour != null)
            {
                await cour.Copy(course);
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var cour = await _context.Courses.FindAsync(id);
            if (cour != null)
            {
                _context.Courses.Remove(cour);
                return true;
            }
            return false;
        }
        public async Task<bool> Save()
        {

            try
            {
                if (_context.Database.CurrentTransaction == null)
                {
                    await _context.Database.BeginTransactionAsync();
                }

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (_context.Database.CurrentTransaction != null)
                {
                    await _context.Database.RollbackTransactionAsync();
                }
                return false;
            }
        }

        public async Task<IEnumerable<Teacher>> GetTeachers(int id)
        {
            var courseTeacher = _context
                .Set<CourseTeacher>()
                .Include(x => x.Course)
                .Include(x => x.Teacher)
                .Where(x => x.Course.Id == id)
                .ToList();
            if(courseTeacher.Count == 0){
                return null;
            }
            return courseTeacher.Select(cs => cs.Teacher);
        }
        public async Task<IEnumerable<Student>> GetStudents(int id)
        {
            var courseStudent = _context
                .Set<CourseStudent>()
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(cs => cs.Course.Id == id)
                .ToList();
            if (courseStudent.Count == 0)
            {
                return null;
            }
            return courseStudent.Select(cs => cs.Student);
        }
    }
}
