namespace WMS.Domain.Entities
{
    /// <summary>
    /// 用户实体，表示系统中的登录用户
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名，用于登录，全局唯一
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// 密码哈希值，存储加密后的密码
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 账号是否启用：true 表示启用，false 表示禁用
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// 外键：所属角色 Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 导航属性：所属角色
        /// </summary>
        public Role Role { get; set; } = null!;
    }
}
