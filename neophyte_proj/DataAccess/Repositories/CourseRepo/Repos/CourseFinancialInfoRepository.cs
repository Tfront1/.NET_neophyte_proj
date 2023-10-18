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
    public class CourseFinancialInfoRepository : ICourseFinancialInfoRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseFinancialInfoRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(CourseFinancialInfo courseFinancialInfo)
        {
            _ = courseFinancialInfo ?? throw new ArgumentNullException(nameof(courseFinancialInfo));
            await _context.CourseFinancialInfos.AddAsync(courseFinancialInfo);
        }

        public async Task Delete(int id)
        {
            var courFi = await _context.CourseFinancialInfos.FindAsync(id);
            if (courFi != null)
            {
                _context.CourseFinancialInfos.Remove(courFi);
            }
        }

        public async Task<IEnumerable<CourseFinancialInfo>> GetAll()
        {
            return _context.CourseFinancialInfos;
        }

        public async Task<CourseFinancialInfo> GetByCourseId(int id)
        {
            return await _context.CourseFinancialInfos.FirstOrDefaultAsync(x => x.CourseId == id);
        }

        public async Task<CourseFinancialInfo> GetById(int id)
        {
            return await _context.CourseFinancialInfos.FindAsync(id);
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

        public async Task Update(CourseFinancialInfo courseFinancialInfo)
        {
            _ = courseFinancialInfo ?? throw new ArgumentNullException(nameof(courseFinancialInfo));
            var courFi = await _context.CourseFinancialInfos.FindAsync(courseFinancialInfo.Id);
            if (courFi != null)
            {
                await courFi.Copy(courseFinancialInfo);
            }
        }
    }
}
