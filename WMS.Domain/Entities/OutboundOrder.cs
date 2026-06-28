using WMS.Domain.Enums;

namespace WMS.Domain.Entities
{
    /// <summary>
    /// 出库单实体，记录一次出库操作的主信息
    /// </summary>
    public class OutboundOrder : BaseEntity
    {
        /// <summary>
        /// 出库单号，唯一标识一次出库操作
        /// </summary>
        public string OrderNo { get; set; } = string.Empty;

        /// <summary>
        /// 出库类型：销售出库、调拨出库、报废出库、其他
        /// </summary>
        public OutboundType OutboundType { get; set; }

        /// <summary>
        /// 订单状态：待处理、处理中、已完成、已取消
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        /// <summary>
        /// 客户名称
        /// </summary>
        public string? Customer { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 外键：操作人用户 Id
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 导航属性：操作人
        /// </summary>
        public User Operator { get; set; } = null!;

        /// <summary>
        /// 导航属性：出库单明细集合
        /// </summary>
        public ICollection<OutboundOrderItem> Items { get; set; } = new List<OutboundOrderItem>();
    }
}
