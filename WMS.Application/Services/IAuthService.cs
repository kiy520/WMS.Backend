using WMS.Application.DTOs;

namespace WMS.Application.Services
{
    /// <summary>
    /// 认证服务接口，定义登录校验和 JWT 令牌生成功能
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 用户登录，验证用户名密码并返回 JWT 令牌
        /// </summary>
        /// <param name="request">登录请求 DTO</param>
        /// <returns>登录响应 DTO，包含令牌和用户信息；验证失败返回 null</returns>
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}
