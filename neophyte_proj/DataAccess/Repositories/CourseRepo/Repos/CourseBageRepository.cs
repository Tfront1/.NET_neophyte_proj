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
        public IEnumerable<CourseBage> GetAll()
        {
            return _context.CourseBags;
        }
        public CourseBage GetById(int id)
        {
            return _context.CourseBags.Find(id);
        }
        public IEnumerable<CourseBage> GetByCourseId(int id)
        {
            return _context.CourseBags.Where(x => x.Id == id);
        }
        public void Create(CourseBage courseBage)
        {
            _context.CourseBags.Add(courseBage);
        }
        public void Update(CourseBage courseBage)
        {
            var courBg = _context.CourseBags.Find(courseBage.Id);
            if (courBg != null)
            {
                courBg.Copy(courseBage);
            }
        }
        public void Delete(int id)
        {
            var courBg = _context.CourseBags.Find(id);
            if (courBg != null)
            {
                _context.CourseBags.Remove(courBg);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
