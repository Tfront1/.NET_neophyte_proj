using DataAccess.Repositories.CourseRepo.Interfaces;
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

        public void Create(CourseFinancialInfo courseFinancialInfo)
        {
            _context.CourseFinancialInfos.Add(courseFinancialInfo);
        }

        public void Delete(int id)
        {
            var courFi = _context.CourseFinancialInfos.Find(id);
            if (courFi != null)
            {
                _context.CourseFinancialInfos.Remove(courFi);
            }
        }

        public IEnumerable<CourseFinancialInfo> GetAll()
        {
            return _context.CourseFinancialInfos;
        }

        public CourseFinancialInfo GetByCourseId(int id)
        {
            return _context.CourseFinancialInfos.FirstOrDefault(x => x.CourseId == id);
        }

        public CourseFinancialInfo GetById(int id)
        {
            return _context.CourseFinancialInfos.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(CourseFinancialInfo courseFinancialInfo)
        {
            var courFi = _context.CourseFinancialInfos.Find(courseFinancialInfo.Id);
            if (courFi != null)
            {
                courFi.Copy(courseFinancialInfo);
            }
        }
    }
}
