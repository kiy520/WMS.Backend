using WMS.Application.DTOs;

namespace WMS.Application.Services
{
    /// <summary>
    /// 商品服务接口，定义商品增删改查和库存预警功能
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 获取所有商品列表
        /// </summary>
        /// <returns>商品 DTO 列表</returns>
        Task<IEnumerable<ProductDto>> GetAllAsync();

        /// <summary>
        /// 根据 Id 获取商品
        /// </summary>
        /// <param name="id">商品 Id</param>
        /// <returns>商品 DTO，未找到返回 null</returns>
        Task<ProductDto?> GetByIdAsync(int id);

        /// <summary>
        /// 创建新商品
        /// </summary>
        /// <param name="request">创建商品请求 DTO</param>
        /// <returns>创建后的商品 DTO</returns>
        Task<ProductDto> CreateAsync(CreateProductRequest request);

        /// <summary>
        /// 更新商品信息
        /// </summary>
        /// <param name="id">商品 Id</param>
        /// <param name="request">更新商品请求 DTO</param>
        /// <returns>更新后的商品 DTO；商品不存在返回 null</returns>
        Task<ProductDto?> UpdateAsync(int id, UpdateProductRequest request);

        /// <summary>
        /// 软删除商品
        /// </summary>
        /// <param name="id">商品 Id</param>
        /// <returns>删除成功返回 true，商品不存在返回 false</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 获取库存不足的商品列表（库存量低于安全库存阈值）
        /// </summary>
        /// <returns>库存不足的商品 DTO 列表</returns>
        Task<IEnumerable<ProductDto>> GetLowStockProductsAsync();
    }
}
