using DataAccess.Repositories.StudentRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.StudentRepo.Repos
{
    public class StudentAccountInfoRepository : IStudentAccountInfoRepository
    {
        private readonly NeophyteApplicationContext _context;
        public StudentAccountInfoRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(StudentAccountInfo studentAccountInfo)
        {
            await _context.StudentAccountInfos.AddAsync(studentAccountInfo);
        }

        public async Task Delete(int id)
        {
            var studAi = await _context.StudentAccountInfos.FindAsync(id);
            if (studAi != null) {
                _context.StudentAccountInfos.Remove(studAi);
            }
        }

        public async Task<IEnumerable<StudentAccountInfo>> GetAll()
        {
            return _context.StudentAccountInfos;
        }

        public async Task<StudentAccountInfo> GetById(int id)
        {
            return await _context.StudentAccountInfos.FindAsync(id);
        }

        public async Task<StudentAccountInfo> GetByStudentId(int id)
        {
            return _context.StudentAccountInfos.FirstOrDefault(x=>x.StudentId == id);
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

        public async Task Update(StudentAccountInfo studentAccountInfo)
        {
            var studAi = await _context.StudentAccountInfos.FindAsync(studentAccountInfo.Id);
            if(studAi != null){
                await studAi.Copy(studentAccountInfo);
            }
        }
    }
}
