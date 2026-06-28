namespace WMS.Domain.Entities
{
    /// <summary>
    /// 角色实体，用于基于角色的访问控制（RBAC）
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// 角色名称，如 Admin、WarehouseKeeper 等
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 角色描述，说明角色的职责和权限范围
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 导航属性：该角色下的所有用户
        /// </summary>
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
