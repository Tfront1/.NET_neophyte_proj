using DataAccess.Repositories.TeacherRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.TeacherRepo.Repos
{
    public class TeacherAccountInfoRepository : ITeacherAccountInfoRepository
    {
        private readonly NeophyteApplicationContext _context;
        public TeacherAccountInfoRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(TeacherAccountInfo teacherAccountInfo)
        {
            await _context.TeacherAccountInfos.AddAsync(teacherAccountInfo);
        }

        public async Task Delete(int id)
        {
            var techAi = await _context.TeacherAccountInfos.FindAsync(id);
            if (techAi != null) {
                _context.TeacherAccountInfos.Remove(techAi);
            }
        }

        public async Task<IEnumerable<TeacherAccountInfo>> GetAll()
        {
            return _context.TeacherAccountInfos;
        }

        public async Task<TeacherAccountInfo> GetById(int id)
        {
            return await _context.TeacherAccountInfos.FindAsync(id);
        }

        public async Task<TeacherAccountInfo> GetByTeacherId(int id)
        {
            return _context.TeacherAccountInfos.FirstOrDefault(x=>x.TeacherId == id);
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

        public async Task Update(TeacherAccountInfo teacherAccountInfo)
        {
            var techAi = await _context.TeacherAccountInfos.FindAsync(teacherAccountInfo.Id);
            if (techAi != null)
            {
                await techAi.Copy(teacherAccountInfo);
            }
        }
    }
}
