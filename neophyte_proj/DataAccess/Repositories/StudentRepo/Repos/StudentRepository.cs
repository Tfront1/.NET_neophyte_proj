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
    public class StudentRepository : IStudentRepository
    {
        private readonly NeophyteApplicationContext _context;
        public StudentRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
        }

        public void Delete(int id)
        {
            var stud = _context.Students.Find(id);
            if (stud != null) {
                _context.Students.Remove(stud);
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
