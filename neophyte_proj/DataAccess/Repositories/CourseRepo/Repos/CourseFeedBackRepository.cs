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
    public class CourseFeedBackRepository : ICourseFeedBackRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseFeedBackRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseFeedBack>> GetAll()
        {
            return _context.CourseFeedBacks;
        }
        public async Task<CourseFeedBack> GetById(int id)
        {
            return await _context.CourseFeedBacks.FindAsync(id);
        }
        public async Task<IEnumerable<CourseFeedBack>> GetByCourseId(int id)
        {
            return await _context.CourseFeedBacks.Where(x => x.CourseId == id).ToListAsync();
        }
        public async Task Create(CourseFeedBack courseFeedBack)
        {
            await _context.CourseFeedBacks.AddAsync(courseFeedBack);
        }
        public async Task Update(CourseFeedBack courseFeedBack)
        {
            var courFg = await _context.CourseFeedBacks.FindAsync(courseFeedBack.Id);
            if (courFg != null)
            {
                await courFg.Copy(courseFeedBack);
            }
        }
        public async Task Delete(int id)
        {
            var courFg = await _context.CourseFeedBacks.FindAsync(id);
            if (courFg != null)
            {
                _context.CourseFeedBacks.Remove(courFg);
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
