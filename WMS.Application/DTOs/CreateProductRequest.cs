namespace WMS.Application.DTOs
{
    /// <summary>
    /// 创建商品请求 DTO
    /// </summary>
    public class CreateProductRequest
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string code { get; set; } = string.Empty;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// 商品规格
        /// </summary>
        public string? specification { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string unit { get; set; } = string.Empty;

        /// <summary>
        /// 商品分类
        /// </summary>
        public string? category { get; set; }

        /// <summary>
        /// 安全库存阈值
        /// </summary>
        public int safetyStock { get; set; }
    }
}
