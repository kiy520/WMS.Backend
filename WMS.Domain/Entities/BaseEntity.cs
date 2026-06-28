namespace WMS.Domain.Entities
{
    /// <summary>
    /// 核心实体基类，提供统一的标识、时间戳和软删除支持
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 软删除标记：true 表示已删除，false 表示正常
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后更新时间，创建时为 null，每次修改后更新
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
