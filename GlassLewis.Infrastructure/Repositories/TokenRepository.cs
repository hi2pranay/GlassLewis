using GlassLewis.Core.GlassLewis.Interfaces;
using GlassLewis.Core.GlassLewis.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace GlassLewis.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly GlassLewisDbContext _glassLewisDbContext;
        public IConfiguration _configuration;

        public TokenRepository(GlassLewisDbContext glassLewisDbContext, IConfiguration configuration)
        {
            _glassLewisDbContext = glassLewisDbContext;
            _configuration = configuration;
        }

        public async Task<string> GetToken(UserInfo _userData)
        {
            try
            {
                if (_userData != null && _userData.Email != null && _userData.Password != null)
                {
                    var user = _glassLewisDbContext.UserInfo.FirstOrDefault(u => u.Email == _userData.Email && u.Password == _userData.Password);

                    if (user != null)
                    {
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.Email),
                        new Claim("UserName", user.Email),
                        new Claim("Email", user.Email)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                                                        _configuration["Jwt:Issuer"],
                                                        _configuration["Jwt:Audience"],
                                                        claims,
                                                        expires: DateTime.UtcNow.AddMinutes(10),
                                                        signingCredentials: signIn);

                        return new JwtSecurityTokenHandler().WriteToken(token);
                    }
                    else
                    {
                        throw new Exception("Invalid credentials");
                    }
                }
                else
                {
                    throw new Exception("Username and Password are empty");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
