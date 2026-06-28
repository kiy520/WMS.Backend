using System.Linq.Expressions;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Data
{
    /// <summary>
    /// EF Core 表达式辅助类，用于动态构建软删除的全局查询过滤器
    /// </summary>
    public static class EfExpressionHelper
    {
        /// <summary>
        /// 构建 BaseEntity 派生类的软删除过滤表达式
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns>Lambda 表达式：e => !e.IsDeleted</returns>
        public static LambdaExpression BuildSoftDeleteFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
            var filter = Expression.Lambda(Expression.Not(property), parameter);
            return filter;
        }
    }
}
