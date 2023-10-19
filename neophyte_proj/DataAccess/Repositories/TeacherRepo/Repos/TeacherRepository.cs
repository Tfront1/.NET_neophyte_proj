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

        public async Task Create(Teacher teacher)
        {
            _ = teacher ?? throw new ArgumentNullException(nameof(teacher));
            await _context.Teachers.AddAsync(teacher); 
        }

        public async Task Delete(int id)
        {
            var teach = await _context.Teachers.FindAsync(id);
            if (teach != null){
                _context.Teachers.Remove(teach);
            }
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

        public async Task Update(Teacher teacher)
        {
            _ = teacher ?? throw new ArgumentNullException(nameof(teacher));
            var teach = await _context.Teachers.FindAsync(teacher.Id);
            if (teach != null)
            {
                await teach.Copy(teacher);
            }
        }

        public async Task<IEnumerable<Course>> GetCourses(Teacher teacher)
        {
            _ = teacher ?? throw new ArgumentNullException(nameof(teacher));
            var courseTeacher = await _context
                .Set<CourseTeacher>()
                .Include(x => x.Course)
                .Include(x => x.Teacher)
                .Where(x => x.TeacherId == teacher.Id)
                .ToListAsync();

            return courseTeacher.Select(cs => cs.Course);
        }
    }
}
