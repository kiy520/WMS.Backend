using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Data
{
    /// <summary>
    /// 数据库上下文，管理所有实体与数据库的映射关系
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 构造函数，通过依赖注入传入数据库连接配置
        /// </summary>
        /// <param name="options">数据库上下文配置选项</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 商品表
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 入库单主表
        /// </summary>
        public DbSet<InboundOrder> InboundOrders { get; set; }

        /// <summary>
        /// 入库单明细表
        /// </summary>
        public DbSet<InboundOrderItem> InboundOrderItems { get; set; }

        /// <summary>
        /// 出库单主表
        /// </summary>
        public DbSet<OutboundOrder> OutboundOrders { get; set; }

        /// <summary>
        /// 出库单明细表
        /// </summary>
        public DbSet<OutboundOrderItem> OutboundOrderItems { get; set; }

        /// <summary>
        /// 模型创建时配置实体映射关系和全局过滤器
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 统一全局查询过滤器：自动过滤已软删除的实体
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(
                            EfExpressionHelper.BuildSoftDeleteFilter(entityType.ClrType));
                }
            }

            // 用户实体配置
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasOne(e => e.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 角色实体配置
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // 商品实体配置
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Code).IsUnique();
            });

            // 入库单实体配置
            modelBuilder.Entity<InboundOrder>(entity =>
            {
                entity.HasIndex(e => e.OrderNo).IsUnique();
                entity.HasOne(e => e.Operator)
                      .WithMany()
                      .HasForeignKey(e => e.OperatorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 入库单明细实体配置
            modelBuilder.Entity<InboundOrderItem>(entity =>
            {
                entity.HasOne(e => e.InboundOrder)
                      .WithMany(o => o.Items)
                      .HasForeignKey(e => e.InboundOrderId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.InboundOrderItems)
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 出库单实体配置
            modelBuilder.Entity<OutboundOrder>(entity =>
            {
                entity.HasIndex(e => e.OrderNo).IsUnique();
                entity.HasOne(e => e.Operator)
                      .WithMany()
                      .HasForeignKey(e => e.OperatorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 出库单明细实体配置
            modelBuilder.Entity<OutboundOrderItem>(entity =>
            {
                entity.HasOne(e => e.OutboundOrder)
                      .WithMany(o => o.Items)
                      .HasForeignKey(e => e.OutboundOrderId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.OutboundOrderItems)
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 重写 SaveChanges，自动更新时间戳和软删除
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>受影响的行数</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // 自动设置 UpdatedAt 时间戳
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
