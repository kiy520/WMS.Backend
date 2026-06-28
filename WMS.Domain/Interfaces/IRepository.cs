using System.Linq.Expressions;
using WMS.Domain.Entities;

namespace WMS.Domain.Interfaces
{
    /// <summary>
    /// 泛型仓储接口，定义实体数据的增删改查操作契约
    /// </summary>
    /// <typeparam name="T">实体类型，必须继承自 BaseEntity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键 Id</param>
        /// <returns>实体对象，未找到时返回 null</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// 获取所有实体（已自动过滤软删除记录）
        /// </summary>
        /// <returns>实体集合</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// 根据条件查询实体列表
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>满足条件的实体集合</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">要新增的实体</param>
        Task AddAsync(T entity);

        /// <summary>
        /// 批量新增实体
        /// </summary>
        /// <param name="entities">要新增的实体集合</param>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        void Update(T entity);

        /// <summary>
        /// 软删除实体（将 IsDeleted 设置为 true）
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        void SoftDelete(T entity);

        /// <summary>
        /// 根据主键软删除实体
        /// </summary>
        /// <param name="id">主键 Id</param>
        Task SoftDeleteByIdAsync(int id);

        /// <summary>
        /// 获取满足条件的实体数量
        /// </summary>
        /// <param name="predicate">查询条件表达式，为 null 时统计所有记录</param>
        /// <returns>实体数量</returns>
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

        /// <summary>
        /// 判断是否存在满足条件的实体
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <returns>存在返回 true，否则返回 false</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
