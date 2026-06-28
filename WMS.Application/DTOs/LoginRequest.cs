namespace WMS.Application.DTOs
{
    /// <summary>
    /// 登录请求 DTO，用于用户身份验证
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; } = string.Empty;

        /// <summary>
        /// 密码（明文，服务端进行哈希校验）
        /// </summary>
        public string password { get; set; } = string.Empty;
    }
}
