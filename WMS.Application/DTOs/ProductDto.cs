namespace WMS.Application.DTOs
{
    /// <summary>
    /// 商品 DTO，用于商品信息的传输
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// 商品 Id
        /// </summary>
        public int id { get; set; }

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
        /// 库存数量
        /// </summary>
        public int stockQuantity { get; set; }

        /// <summary>
        /// 安全库存阈值
        /// </summary>
        public int safetyStock { get; set; }

        /// <summary>
        /// 是否库存不足（低于安全库存）
        /// </summary>
        public bool isLowStock => stockQuantity < safetyStock;
    }
}
