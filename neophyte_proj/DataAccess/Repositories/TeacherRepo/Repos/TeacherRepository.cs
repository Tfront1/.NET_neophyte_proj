using DataAccess.Repositories.TeacherRepo.Interfaces;
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

namespace DataAccess.Repositories.TeacherRepo.Repos
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly NeophyteApplicationContext _context;
        public TeacherRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Teacher teacher)
        {
            _ = teacher ?? throw new ArgumentNullException(nameof(teacher));
            try
            {
                await _context.Teachers.AddAsync(teacher);
                return true;
            }
            catch 
            {
                return false;
            }    
        }

        public async Task<bool> Delete(int id)
        {
            var teach = await _context.Teachers.FindAsync(id);
            if (teach != null){
                _context.Teachers.Remove(teach);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return _context.Teachers;
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _context.Teachers.FindAsync(id);
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

        public async Task<bool> Update(Teacher teacher)
        {
            _ = teacher ?? throw new ArgumentNullException(nameof(teacher));
            var teach = await _context.Teachers.FindAsync(teacher.Id);
            if (teach != null)
            {
                await teach.Copy(teacher);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Course>> GetCourses(int id)
        {
            var courseTeacher = _context
                .Set<CourseTeacher>()
                .Include(x => x.Course)
                .Include(x => x.Teacher)
                .Where(x => x.TeacherId == id)
                .ToList();

            if (courseTeacher.Count() == 0) {
                return null;
            }
            return courseTeacher.Select(cs => cs.Course);
        }
        public async Task<bool> AddCourse(CourseTeacher courseTeacher)
        {
            var teacher = await _context.Teachers.FindAsync(courseTeacher.TeacherId);
            var course = await _context.Courses.FindAsync(courseTeacher.CourseId);

            if (course == null || teacher == null)
            {
                return false;
            }
            courseTeacher.Course = course;
            courseTeacher.Teacher = teacher;

            _context.Set<CourseTeacher>().Add(courseTeacher);

            return true;
        }
        public async Task<IEnumerable<TeacherFeedBack>> GetFeedbacks(int id)
        {
            var teacherFeedBack = _context
                .TeacherFeedBacks
                .Where(x => x.TeacherId == id)
                .ToList();
            if (teacherFeedBack.Count == 0)
            {
                return null;
            }
            return teacherFeedBack;
        }
    }
}
