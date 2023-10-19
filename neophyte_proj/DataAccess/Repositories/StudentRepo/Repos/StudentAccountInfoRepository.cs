using DataAccess.Repositories.StudentRepo.Interfaces;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
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

        public async Task<bool> Create(StudentAccountInfo studentAccountInfo)
        {
            _ = studentAccountInfo ?? throw new ArgumentNullException(nameof(studentAccountInfo));
            try
            {
                await _context.StudentAccountInfos.AddAsync(studentAccountInfo);
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            var studAi = await _context.StudentAccountInfos.FindAsync(id);
            if (studAi != null) {
                _context.StudentAccountInfos.Remove(studAi);
                return true;
            }
            return false;
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

        public async Task<bool> Update(StudentAccountInfo studentAccountInfo)
        {
            _ = studentAccountInfo ?? throw new ArgumentNullException(nameof(studentAccountInfo));
            var studAi = await _context.StudentAccountInfos.FindAsync(studentAccountInfo.Id);
            if(studAi != null){
                await studAi.Copy(studentAccountInfo);
                return true;
            }
            return false;
        }
    }
}
