namespace WMS.Domain.Entities
{
    /// <summary>
    /// 商品实体，表示仓库中管理的产品
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// 商品编码，唯一标识一个商品
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 商品规格（如尺寸、型号等）
        /// </summary>
        public string? Specification { get; set; }

        /// <summary>
        /// 计量单位（如个、箱、千克等）
        /// </summary>
        public string Unit { get; set; } = string.Empty;

        /// <summary>
        /// 商品分类
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockQuantity { get; set; } = 0;

        /// <summary>
        /// 安全库存阈值，低于此值时触发预警
        /// </summary>
        public int SafetyStock { get; set; } = 0;

        /// <summary>
        /// 导航属性：该商品的入库明细集合
        /// </summary>
        public ICollection<InboundOrderItem> InboundOrderItems { get; set; } = new List<InboundOrderItem>();

        /// <summary>
        /// 导航属性：该商品的出库明细集合
        /// </summary>
        public ICollection<OutboundOrderItem> OutboundOrderItems { get; set; } = new List<OutboundOrderItem>();
    }
}
