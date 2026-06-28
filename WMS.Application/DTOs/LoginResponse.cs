namespace WMS.Application.DTOs
{
    /// <summary>
    /// 登录响应 DTO，包含 JWT 令牌和用户基本信息
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// JWT 访问令牌
        /// </summary>
        public string token { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; } = string.Empty;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string roleName { get; set; } = string.Empty;
    }
}
