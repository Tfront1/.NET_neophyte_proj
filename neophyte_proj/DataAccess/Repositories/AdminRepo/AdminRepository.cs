using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using neophyte_proj.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.AdminRepo
{
    public class AdminRepository : IAdminRepository
    {
        private readonly NeophyteApplicationContext _context;
        public AdminRepository(NeophyteApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Admin>> GetByUsername(string username)
        {
            return _context.Admins.Where(x => x.UserName == username).ToList();
        }
    }
}
