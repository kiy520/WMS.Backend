using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs;
using WMS.Application.Services;

namespace WMS.API.Controllers
{
    /// <summary>
    /// 认证控制器，处理用户登录和令牌签发
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// 认证服务，处理登录校验和 JWT 生成
        /// </summary>
        private readonly IAuthService _authService;

        /// <summary>
        /// 构造函数，通过依赖注入获取认证服务
        /// </summary>
        /// <param name="authService">认证服务实例</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 用户登录，验证用户名密码并返回 JWT 令牌
        /// </summary>
        /// <param name="request">登录请求 DTO</param>
        /// <returns>登录成功返回令牌和用户信息；用户名或密码错误返回 401</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (result == null)
            {
                return Unauthorized(new { message = "用户名或密码错误" });
            }

            return Ok(result);
        }
    }
}
