﻿using DataAccess.Models.IntermediateModels;
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

        public async Task<bool> Create(Student student)
        {
            _ = student ?? throw new ArgumentNullException(nameof(student));
            try
            {
                await _context.Students.AddAsync(student);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud != null)
            {
                _context.Students.Remove(stud);
                return true;
            }
            return false;
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

        public async Task<bool> Update(Student student)
        {
            _ = student ?? throw new ArgumentNullException(nameof(student));
            var stud = await _context.Students.FindAsync(student.Id);
            if (stud != null)
            {
                await stud.Copy(student);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Course>> GetCourses(int id)
        {
            var courseStudent = _context
                .Set<CourseStudent>()
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(cs => cs.Student.Id == id).
                ToList();
            if (courseStudent.Count() == 0) {
                return null;
            }
            return courseStudent.Select(cs => cs.Course);
        }
        public async Task<bool> AddCourse(CourseStudent courseStudent)
        {
            var student = await _context.Students.FindAsync(courseStudent.StudentId);
            var course = await _context.Courses.FindAsync(courseStudent.CourseId);

            if (course == null || student== null)
            {
                return false;
            }
            courseStudent.Course = course;
            courseStudent.Student = student;

            _context.Set<CourseStudent>().Add(courseStudent);

            return true;
        }
        public async Task<IEnumerable<CourseBage>> GetBages(int id){
            var courseBage = _context
                .Set<BageStudent>()
                .Include(x => x.CourseBage)
                .Include(x => x.Student)
                .Where(cs => cs.Student.Id == id).
                ToList();
            if (courseBage.Count() == 0)
            {
                return null;
            }
            return courseBage.Select(cs => cs.CourseBage);
        }

        public async Task<bool> AddBage(BageStudent bageStudent) {
            var student = await _context.Students.FindAsync(bageStudent.StudentId);
            var courseBage = await _context.CourseBags.FindAsync(bageStudent.BageId);

            if (courseBage == null || student == null)
            {
                return false;
            }
            bageStudent.CourseBage = courseBage;
            bageStudent.Student = student;

            _context.Set<BageStudent>().Add(bageStudent);

            return true;
        }
    }
}
