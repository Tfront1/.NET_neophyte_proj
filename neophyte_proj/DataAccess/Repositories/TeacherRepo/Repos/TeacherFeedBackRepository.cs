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

        public async Task<bool> Create(TeacherFeedBack teacherFeedBack)
        {
            _ = teacherFeedBack ?? throw new ArgumentNullException(nameof(teacherFeedBack));
            try
            {
                await _context.TeacherFeedBacks.AddAsync(teacherFeedBack);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var techFb = await _context.TeacherFeedBacks.FindAsync(id);
            if (techFb != null) {
                _context.TeacherFeedBacks.Remove(techFb);
                return true;
            }
            return false;
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

        public async Task<bool> Update(TeacherFeedBack teacherFeedBack)
        {
            _ = teacherFeedBack ?? throw new ArgumentNullException(nameof(teacherFeedBack));
            var techFb = await _context.TeacherFeedBacks.FindAsync(teacherFeedBack.Id);
            if (techFb != null) {
                await techFb.Copy(teacherFeedBack);
                return true;
            }
            return false;
        }
    }
}
