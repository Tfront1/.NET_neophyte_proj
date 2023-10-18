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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly NeophyteApplicationContext _context;
        public TeacherRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher); 
        }

        public void Delete(int id)
        {
            var teach = _context.Teachers.Find(id);
            if (teach != null){
                _context.Teachers.Remove(teach);
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers;
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
