namespace WMS.Domain.Entities
{
    /// <summary>
    /// 入库单明细实体，记录入库单中每个商品的入库数量和详情
    /// </summary>
    public class InboundOrderItem : BaseEntity
    {
        /// <summary>
        /// 外键：所属入库单 Id
        /// </summary>
        public int InboundOrderId { get; set; }

        /// <summary>
        /// 导航属性：所属入库单
        /// </summary>
        public InboundOrder InboundOrder { get; set; } = null!;

        /// <summary>
        /// 外键：商品 Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 导航属性：商品
        /// </summary>
        public Product Product { get; set; } = null!;

        /// <summary>
        /// 入库数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
