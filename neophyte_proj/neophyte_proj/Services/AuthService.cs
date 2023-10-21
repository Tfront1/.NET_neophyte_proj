using AutoMapper;
using DataAccess.Repositories.StudentRepo.Interfaces;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using DataAccess.Repositories.TeacherRepo.Repos;
using Microsoft.IdentityModel.Tokens;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models.Auth;

namespace WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IStudentAccountInfoRepository _studentAccountInfoRepository;
        private readonly ITeacherAccountInfoRepository _teacherAccountInfoRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, IStudentAccountInfoRepository studentAccountInfoRepository,
            ITeacherAccountInfoRepository teacherAccountInfoRepository,IConfiguration configuration)
        {
            _mapper = mapper;
            _studentAccountInfoRepository = studentAccountInfoRepository;
            _teacherAccountInfoRepository = teacherAccountInfoRepository;
            _configuration = configuration;
        }
        public async Task<string> StudentLogin(UserStudentDto userStudentDto)
        {
            var studs = await _studentAccountInfoRepository.GetByUsername(userStudentDto.UserName);
            foreach (StudentAccountInfo s in studs) {
                if (s.Password == userStudentDto.Password) {
                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.NameIdentifier, s.UserName),
                        new Claim(ClaimTypes.Role, "Student")
                    };
                    return GenerateToken(claims);
                }
            }
            return null;
        }

        public async Task<string> TeacherLogin(UserTeacherDto userTeacherDto)
        {
            var teachs = await _teacherAccountInfoRepository.GetByUsername(userTeacherDto.UserName);
            foreach (TeacherAccountInfo s in teachs)
            {
                if (s.Password == userTeacherDto.Password)
                {
                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.NameIdentifier, s.UserName),
                        new Claim(ClaimTypes.Role, "Teacher")
                    };
                    return GenerateToken(claims);
                }
            }
            return null;
        }

        private string GenerateToken(List<Claim> claims) {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWTStrings:jwtstr"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
