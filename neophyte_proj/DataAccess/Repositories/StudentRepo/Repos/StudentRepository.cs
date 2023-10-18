using DataAccess.Repositories.StudentRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task Create(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task Delete(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud != null)
            {
                _context.Students.Remove(stud);
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return _context.Students;
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
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

        public async Task Update(Student student)
        {
            var stud = await _context.Students.FindAsync(student.Id);
            if (stud != null)
            {
                await stud.Copy(student);
            }
        }

        public async Task<IEnumerable<Course>> GetCourses(Student student)
        {
            var courseStudent = await _context
                .Set<CourseStudent>()
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(cs => cs.Student.Id == student.Id)
                .ToListAsync();

            return courseStudent.Select(cs => cs.Course);
        }
    }
}
