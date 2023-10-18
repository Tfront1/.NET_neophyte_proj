using DataAccess.Repositories.TeacherRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
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
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task Update(Teacher teacher)
        {
            var teach = await _context.Teachers.FindAsync(teacher.Id);
            if (teach != null)
            {
                await teach.Copy(teacher);
            }
        }
    }
}
