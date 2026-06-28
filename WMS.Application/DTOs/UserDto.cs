namespace WMS.Application.DTOs
{
    /// <summary>
    /// 用户 DTO，用于用户信息的传输
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 用户 Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; } = string.Empty;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string realName { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string? phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string? email { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool isActive { get; set; }

        /// <summary>
        /// 角色 Id
        /// </summary>
        public int roleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string roleName { get; set; } = string.Empty;
    }
}
