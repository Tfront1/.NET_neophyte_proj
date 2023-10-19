using DataAccess.Repositories.CourseRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CourseRepo.Repos
{
    public class CourseBageRepository : ICourseBageRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseBageRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseBage>> GetAll()
        {
            return _context.CourseBags;
        }
        public async Task<CourseBage> GetById(int id)
        {
            return await _context.CourseBags.FindAsync(id);
        }
        public async Task<IEnumerable<CourseBage>> GetByCourseId(int id)
        {
            return await _context.CourseBags.Where(x => x.CourseId == id).ToListAsync();
        }
        public async Task Create(CourseBage courseBage)
        {
            _ = courseBage ?? throw new ArgumentNullException(nameof(courseBage));
            await _context.CourseBags.AddAsync(courseBage);
        }
        public async Task Update(CourseBage courseBage)
        {
            _ = courseBage ?? throw new ArgumentNullException(nameof(courseBage));
            var courBg = await _context.CourseBags.FindAsync(courseBage.Id);
            if (courBg != null)
            {
                await courBg.Copy(courseBage);
            }
        }
        public async Task Delete(int id)
        {
            var courBg = await _context.CourseBags.FindAsync(id);
            if (courBg != null)
            {
                _context.CourseBags.Remove(courBg);
            }
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
    }
}
