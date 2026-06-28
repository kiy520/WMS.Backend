using Microsoft.EntityFrameworkCore.Storage;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories
{
    /// <summary>
    /// 工作单元实现，管理数据库事务和仓储实例的生命周期
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 数据库上下文实例
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// 当前数据库事务
        /// </summary>
        private IDbContextTransaction? _transaction;

        /// <summary>
        /// 仓储实例缓存，避免重复创建
        /// </summary>
        private readonly Dictionary<Type, object> _repositories = new();

        /// <summary>
        /// 构造函数，通过依赖注入获取数据库上下文
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            // 如果已有缓存实例则直接返回
            if (_repositories.TryGetValue(typeof(T), out var repo))
            {
                return (IRepository<T>)repo;
            }

            // 创建新的仓储实例并缓存
            var repository = new Repository<T>(_context);
            _repositories[typeof(T)] = repository;
            return repository;
        }

        /// <inheritdoc />
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        /// <inheritdoc />
        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <inheritdoc />
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// 释放资源，回滚未提交的事务
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
