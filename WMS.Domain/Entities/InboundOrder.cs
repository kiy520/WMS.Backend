using WMS.Domain.Enums;

namespace WMS.Domain.Entities
{
    /// <summary>
    /// 入库单实体，记录一次入库操作的主信息
    /// </summary>
    public class InboundOrder : BaseEntity
    {
        /// <summary>
        /// 入库单号，唯一标识一次入库操作
        /// </summary>
        public string OrderNo { get; set; } = string.Empty;

        /// <summary>
        /// 入库类型：采购入库、退货入库、调拨入库、其他
        /// </summary>
        public InboundType InboundType { get; set; }

        /// <summary>
        /// 订单状态：待处理、处理中、已完成、已取消
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string? Supplier { get; set; }

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
        /// 导航属性：入库单明细集合
        /// </summary>
        public ICollection<InboundOrderItem> Items { get; set; } = new List<InboundOrderItem>();
    }
}
