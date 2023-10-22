using DataAccess.Models;
using neophyte_proj.DataAccess.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.AdminRepo
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetByUsername(string username);
    }
}
