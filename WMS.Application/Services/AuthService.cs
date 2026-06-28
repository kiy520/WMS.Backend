using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WMS.Application.DTOs;
using WMS.Infrastructure.Data;

namespace WMS.Application.Services
{
    /// <summary>
    /// 认证服务实现，处理用户登录校验和 JWT 令牌生成
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// 应用配置，用于读取 JWT 密钥等配置
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 构造函数，通过依赖注入获取数据库上下文和配置
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="configuration">应用配置</param>
        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            // 根据用户名查找用户（包含角色信息）
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == request.username);

            // 用户不存在或账号已禁用
            if (user == null || !user.IsActive)
            {
                return null;
            }

            // 验证密码哈希（使用 SHA256 进行简单比对，生产环境应使用 BCrypt 等）
            var passwordHash = ComputeHash(request.password);
            if (user.PasswordHash != passwordHash)
            {
                return null;
            }

            // 生成 JWT 令牌
            var token = GenerateJwtToken(user);

            return new LoginResponse
            {
                token = token,
                username = user.Username,
                realName = user.RealName,
                roleName = user.Role?.Name ?? string.Empty
            };
        }

        /// <summary>
        /// 生成 JWT 令牌
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>JWT 令牌字符串</returns>
        private string GenerateJwtToken(Domain.Entities.User user)
        {
            // 从配置读取 JWT 参数
            var jwtKey = _configuration["Jwt:Key"] ?? "WMS_DefaultSecretKey_AtLeast32Chars!";
            var jwtIssuer = _configuration["Jwt:Issuer"] ?? "WMS.Backend";
            var jwtAudience = _configuration["Jwt:Audience"] ?? "WMS.Client";
            var expireMinutes = int.TryParse(_configuration["Jwt:ExpireMinutes"], out var m) ? m : 120;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 构建 Claims
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, user.Role?.Name ?? string.Empty)
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expireMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 计算字符串的 SHA256 哈希值
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>哈希后的十六进制字符串</returns>
        private static string ComputeHash(string input)
        {
            var bytes = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes);
        }
    }
}
