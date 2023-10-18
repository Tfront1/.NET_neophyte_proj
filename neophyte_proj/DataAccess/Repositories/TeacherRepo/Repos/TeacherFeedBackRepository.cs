using DataAccess.Repositories.TeacherRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task Create(TeacherFeedBack teacherFeedBack)
        {
            await _context.TeacherFeedBacks.AddAsync(teacherFeedBack);
        }

        public async Task Delete(int id)
        {
            var techFb = await _context.TeacherFeedBacks.FindAsync(id);
            if (techFb != null) {
                _context.TeacherFeedBacks.Remove(techFb);
            }
        }

        public async Task<IEnumerable<TeacherFeedBack>> GetAll()
        {
            return _context.TeacherFeedBacks;
        }

        public async Task<TeacherFeedBack> GetById(int id)
        {
            return await _context.TeacherFeedBacks.FindAsync(id);
        }

        public async Task<IEnumerable<TeacherFeedBack>> GetByTeacherId(int id)
        {
            return await _context.TeacherFeedBacks.Where(x => x.TeacherId == id).ToListAsync();
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

        public async Task Update(TeacherFeedBack teacherFeedBack)
        {
            var techFb = await _context.TeacherFeedBacks.FindAsync(teacherFeedBack.Id);
            if (techFb != null) {
                await techFb.Copy(teacherFeedBack);
            }
        }
    }
}
