namespace WMS.Domain.Entities
{
    /// <summary>
    /// 出库单明细实体，记录出库单中每个商品的出库数量和详情
    /// </summary>
    public class OutboundOrderItem : BaseEntity
    {
        /// <summary>
        /// 外键：所属出库单 Id
        /// </summary>
        public int OutboundOrderId { get; set; }

        /// <summary>
        /// 导航属性：所属出库单
        /// </summary>
        public OutboundOrder OutboundOrder { get; set; } = null!;

        /// <summary>
        /// 外键：商品 Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 导航属性：商品
        /// </summary>
        public Product Product { get; set; } = null!;

        /// <summary>
        /// 出库数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
