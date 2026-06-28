using WMS.Domain.Entities;

namespace WMS.Domain.Interfaces
{
    /// <summary>
    /// 工作单元接口，管理事务提交和仓储实例的获取
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 获取指定实体类型的仓储实例
        /// </summary>
        /// <typeparam name="T">实体类型，必须继承自 BaseEntity</typeparam>
        /// <returns>仓储实例</returns>
        IRepository<T> Repository<T>() where T : BaseEntity;

        /// <summary>
        /// 提交所有更改到数据库
        /// </summary>
        /// <returns>受影响的行数</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 开始一个数据库事务
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// 提交当前事务
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// 回滚当前事务
        /// </summary>
        Task RollbackTransactionAsync();
    }
}
