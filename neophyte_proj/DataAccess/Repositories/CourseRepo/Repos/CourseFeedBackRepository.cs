﻿using DataAccess.Repositories.CourseRepo.Interfaces;
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
    public class CourseFeedBackRepository : ICourseFeedBackRepository
    {
        private readonly NeophyteApplicationContext _context;
        public CourseFeedBackRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseFeedBack>> GetAll()
        {
            return _context.CourseFeedBacks;
        }
        public async Task<CourseFeedBack> GetById(int id)
        {
            return await _context.CourseFeedBacks.FindAsync(id);
        }
        public async Task<IEnumerable<CourseFeedBack>> GetByCourseId(int id)
        {
            return await _context.CourseFeedBacks.Where(x => x.CourseId == id).ToListAsync();
        }
        public async Task<bool> Create(CourseFeedBack courseFeedBack)
        {
            _ = courseFeedBack ?? throw new ArgumentNullException(nameof(courseFeedBack));
            try
            {
                await _context.CourseFeedBacks.AddAsync(courseFeedBack);
                return true;
            }
            catch 
            {
                return false;
            }
            
        }
        public async Task<bool> Update(CourseFeedBack courseFeedBack)
        {
            _ = courseFeedBack ?? throw new ArgumentNullException(nameof(courseFeedBack));
            var courFg = await _context.CourseFeedBacks.FindAsync(courseFeedBack.Id);
            if (courFg != null)
            {
                await courFg.Copy(courseFeedBack);
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var courFg = await _context.CourseFeedBacks.FindAsync(id);
            if (courFg != null)
            {
                _context.CourseFeedBacks.Remove(courFg);
                return true;
            }
            return false;
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
    }
}
